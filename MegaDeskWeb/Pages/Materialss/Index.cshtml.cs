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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb.Model.MegaDeskDBContext _context;

        public IndexModel(MegaDeskWeb.Model.MegaDeskDBContext context)
        {
            _context = context;
        }

        public IList<Material> Material { get;set; }

        public async Task OnGetAsync()
        {
            Material = await _context.Material.ToListAsync();
        }
    }
}
