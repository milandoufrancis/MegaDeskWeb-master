using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Model
{
    public class Rush
    {
        public int ID { get; set; }
        public int days { get; set; }
        public int priceSmall { get; set; }
        public int priceMedium { get; set; }
        public int priceLarge { get; set; }
        public string friendlyName { get
            {
                if (this.days == 0) return "No Rush";
                return this.days.ToString() + " Days";
            }
        }
        public virtual ICollection<DeskQuote> Quotes { get; set; }
    }
}
