using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskWeb.Model
{
    public class Material
    {
        public int ID { get; set; }
        public string type { get; set; }
        public double cost { get; set; }
        public string friendlyName { get
            {
                return this.type.ToString() + ":  $" + this.cost.ToString();
            }
        }

        public virtual ICollection<Desk> Desks { get; set; }
    }
}
