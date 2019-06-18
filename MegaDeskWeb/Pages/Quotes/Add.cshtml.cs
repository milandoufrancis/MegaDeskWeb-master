using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb.Model;

namespace MegaDeskWeb.Pages.Quotes
{
    public class AddModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public AddModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

            ViewData["MaterialID"] = new SelectList(_context.Material, "ID", "friendlyName");
            ViewData["RushID"] = new SelectList(_context.Rush, "ID", "friendlyName");
            //return Page();
        }
        [BindProperty]
        public Model.Desk Desk { get; set; }
        [BindProperty]
        public Model.DeskQuote Quote { get; set; }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)return Page();

            _context.Desk.Add(Desk);
            _context.SaveChanges();
            Quote.DeskID = Desk.ID;
            Quote.Date = DateTime.Now;
            _context.DeskQuote.Add(Quote);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}