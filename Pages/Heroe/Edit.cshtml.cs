using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Heroes.Data;
using Heroes.Models;

namespace Heroes.Pages_Heroe
{
    public class EditModel : PageModel
    {
        private readonly Heroes.Data.HeroesContext _context;

        public EditModel(Heroes.Data.HeroesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Heroe Heroe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroe =  await _context.Heroe.FirstOrDefaultAsync(m => m.Id == id);
            if (heroe == null)
            {
                return NotFound();
            }
            Heroe = heroe;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Heroe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroeExists(Heroe.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HeroeExists(int id)
        {
            return _context.Heroe.Any(e => e.Id == id);
        }
    }
}
