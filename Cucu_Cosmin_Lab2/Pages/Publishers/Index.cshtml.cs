using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cucu_Cosmin_Lab2.Data;
using Cucu_Cosmin_Lab2.Models;

namespace Cucu_Cosmin_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Cucu_Cosmin_Lab2.Data.Cucu_Cosmin_Lab2Context _context;

        public IndexModel(Cucu_Cosmin_Lab2.Data.Cucu_Cosmin_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; }

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
