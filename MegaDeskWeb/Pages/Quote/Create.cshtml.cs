    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb.Model;

namespace MegaDeskWeb.Pages.Quote
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public CreateModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeskID"] = new SelectList(_context.Desk, "ID", "ID");
        ViewData["RushID"] = new SelectList(_context.Rush, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}