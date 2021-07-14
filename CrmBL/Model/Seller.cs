using CrmBL.Model;
using System.Collections.Generic;

namespace CrmBL
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Check> Checks { get; set; }       // связь с чеком

        public override string ToString()
        {
            return Name;
        }

    }
}
