using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWeb.Model
{
    public class DeskQuote
    {
        public int ID { get; set; }
        [Display(Name = "Desk")]
        public int DeskID { get; set; }
        [Display(Name = "Rush Order")]
        public int RushID { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Price")]
        public string price {
            get
            {
                if(Desk == null)
                    return "$0";
                int basePrice = 200;
                int pricePerInch = 1;
                int minSurfaceArea = 1000;
                int drawersPrice = 50;
                int surfaceArea = Desk.depth * Desk.width;
                int SAOverMin = surfaceArea - minSurfaceArea;
                if (SAOverMin < 0)              SAOverMin = 0;
                int shipping = 0;
                if (surfaceArea < 1000)         shipping = Rush.priceSmall;
                else if (surfaceArea < 2000)    shipping = Rush.priceMedium;
                else                            shipping = Rush.priceLarge;
                decimal price =  basePrice + (SAOverMin * pricePerInch) + (drawersPrice * Desk.drawers) + shipping;
                return price.ToString("C");
            }
        }

        internal DeskQuote Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual Desk Desk { get; set; }
        public virtual Rush Rush { get; set; }
    }
}
