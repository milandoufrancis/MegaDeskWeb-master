using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Model;


namespace MegaDeskWeb.Pages
{
    public class QuotesModel : PageModel
    {

        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public QuotesModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<DeskQuote> DeskQuote { get; set; }
        [BindProperty]
        public string searchString { get; set; }


        public void OnGet(string searchString)
        {
            if (searchString != null)
            {
                this.searchString = searchString;
                DeskQuote = _context.DeskQuote
                    .Include(d => d.Desk)
                    .Include(d => d.Desk.Material)
                    .Include(d => d.Rush)
                    .Where(q => q.CustomerName.Contains(searchString))
                    .ToList();
            }
            else
            {

                this.searchString = "";
                DeskQuote = _context.DeskQuote
                    .Include(d => d.Desk)
                    .Include(d => d.Desk.Material)
                    .Include(d => d.Rush).ToList();
            }
        }
        //public async Task OnGetAsync()
        //{
        //    DeskQuote = await _context.DeskQuote
        //        .Include(d => d.desk)
        //        .Include(d => d.rush).ToListAsync();
        //}
    }
}