using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Model;

namespace MegaDeskWeb.Pages.Quotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public EditModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {

            ViewData["MaterialID"] = new SelectList(_context.Material, "ID", "friendlyName");
            ViewData["RushID"] = new SelectList(_context.Rush, "ID", "friendlyName");

            if (id == null)
            {
                RedirectToPage("./Index");
            }

            Quote =  _context.DeskQuote
                .Include(d => d.Desk)
                .Include(d => d.Desk.Material)
                .Include(d => d.Rush)
                .SingleOrDefault(m => m.ID == id);
            //Desk = _context.Desk.SingleOrDefault(d => d.ID == Quote.DeskID);
            Desk = Quote.Desk;

            if (Desk == null)
            {
                RedirectToPage("./Index");
            }
            return Page();
            //return Page();
        }
        [BindProperty]
        public Model.Desk Desk { get; set; }
        [BindProperty]
        public Model.DeskQuote Quote { get; set; }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)return Page();
            _context.Attach(Desk).State = EntityState.Modified;
            Quote.DeskID = Desk.ID;
            _context.Attach(Quote).State = EntityState.Modified;
            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskExists(Desk.ID) || !QuoteExists(Quote.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuoteExists(int iD)
        {
            return _context.DeskQuote.Any(q => q.ID == iD);
        }

        private bool DeskExists(int id)
        {
            return _context.Desk.Any(e => e.ID == id);
        }
    }
}