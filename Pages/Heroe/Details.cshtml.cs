using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Heroes.Data;
using Heroes.Models;

namespace Heroes.Pages_Heroe
{
    public class DetailsModel : PageModel
    {
        private readonly Heroes.Data.HeroesContext _context;

        public DetailsModel(Heroes.Data.HeroesContext context)
        {
            _context = context;
        }

        public Heroe Heroe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroe = await _context.Heroe.FirstOrDefaultAsync(m => m.Id == id);

            if (heroe is not null)
            {
                Heroe = heroe;

                return Page();
            }

            return NotFound();
        }
    }
}
