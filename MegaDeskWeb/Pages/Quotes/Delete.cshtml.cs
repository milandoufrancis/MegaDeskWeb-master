using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskWeb.Pages.Quotes
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        [BindProperty]
        public Model.Desk Desk { get; set; }

        [BindProperty]
        public Model.DeskQuote Quote { get; set; }

        public DeleteModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
                return Redirect("./Index");
            Quote = _context.DeskQuote
                .Include(d => d.Desk)
                .Include(d => d.Desk.Material)
                .Include(d => d.Rush)
                .SingleOrDefault(m => m.ID == id);
            return Page();
        }

        public ActionResult OnPost(int? id)
        {
            Quote = _context.DeskQuote
                .Include(d => d.Desk)
                .Include(d => d.Desk.Material)
                .Include(d => d.Rush)
                .SingleOrDefault(m => m.ID == id);
            //Delete Quote record
            if (Quote.Desk.Quotes.Any())
            {
                //There is something here.
            }
            else
            {
                //There is nothing here.
            }
            _context.DeskQuote.Attach(Quote);
            _context.DeskQuote.Remove(Quote);
            _context.SaveChanges();
            if (Quote.Desk.Quotes.Any())
            {
                //There is something here.
            }
            else
            {
                _context.Desk.Attach(Quote.Desk);
                _context.Desk.Remove(Quote.Desk);
                _context.SaveChanges();
                //There is nothing here.

            }
            //If Desk Record has no Quote Pointing to it
            //Delete Desk Record
            //return to index
            return Redirect("./Index");
            
        }
    }
}