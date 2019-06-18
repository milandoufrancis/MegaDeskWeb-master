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
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public DetailsModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

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
    }
}
