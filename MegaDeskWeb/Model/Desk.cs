using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Model
{
    public class Desk
    {
        public int ID { get; set; }
        [Display(Name = "Material")]
        public int materialID { get; set; }
        [Display(Name = "Depth(in)")]
        public int depth { get; set; }
        [Display(Name = "Width(in)")]
        public int width { get; set; }
        [Display(Name = "Number of Drawers")]
        public int drawers { get; set; }
        public string friendlyName
        {
            get
            {
                return "" + this.width.ToString() + "in x "
                    + this.depth.ToString() + "in, "
                    + this.drawers.ToString() + " Drawers";
            }
        }
        public virtual Material Material { get; set; }
        public virtual ICollection<DeskQuote> Quotes { get; set; }
    }
}
