using System.Collections.Generic;


namespace CrmBL.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Check> Cheks { get; set; }  // связь с чеком

        public override string ToString()
        {
            return Name;
        }
    }
}
