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
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public DetailsModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

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
    }
}
