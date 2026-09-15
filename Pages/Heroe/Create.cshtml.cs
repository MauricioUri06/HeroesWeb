using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Heroes.Data;
using Heroes.Models;

namespace Heroes.Pages_Heroe
{
    public class CreateModel : PageModel
    {
        private readonly Heroes.Data.HeroesContext _context;

        public CreateModel(Heroes.Data.HeroesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Heroe Heroe { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Heroe.Add(Heroe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
