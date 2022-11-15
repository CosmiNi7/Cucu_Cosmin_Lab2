using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cucu_Cosmin_Lab2.Data;
using Cucu_Cosmin_Lab2.Models;

namespace Cucu_Cosmin_Lab2.Pages.Borrowings
{
    public class DeleteModel : PageModel
    {
        private readonly Cucu_Cosmin_Lab2.Data.Cucu_Cosmin_Lab2Context _context;

        public DeleteModel(Cucu_Cosmin_Lab2.Data.Cucu_Cosmin_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .Include(b => b.Member).FirstOrDefaultAsync(m => m.ID == id);

            if (Borrowing == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing.FindAsync(id);

            if (Borrowing != null)
            {
                _context.Borrowing.Remove(Borrowing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
