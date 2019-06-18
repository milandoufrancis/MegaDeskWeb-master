using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Model;

namespace MegaDeskWeb.Pages.Materialss
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public DeleteModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Material Material { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Material = await _context.Material.SingleOrDefaultAsync(m => m.ID == id);

            if (Material == null)
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

            Material = await _context.Material.FindAsync(id);

            if (Material != null)
            {
                _context.Material.Remove(Material);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
