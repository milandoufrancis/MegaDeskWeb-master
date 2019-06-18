using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Model;

namespace MegaDeskWeb.Pages.RushPage
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public DeleteModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rush Rush { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rush = await _context.Rush.SingleOrDefaultAsync(m => m.ID == id);

            if (Rush == null)
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

            Rush = await _context.Rush.FindAsync(id);

            if (Rush != null)
            {
                _context.Rush.Remove(Rush);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
