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
    public class IndexModel : PageModel
    {
        private readonly Heroes.Data.HeroesContext _context;

        public IndexModel(Heroes.Data.HeroesContext context)
        {
            _context = context;
        }

        public IList<Heroe> Heroe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Heroe = await _context.Heroe.ToListAsync();
        }
    }
}
