using System;
using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Check
    {
        public int CheckId { get; set; }
        public DateTime Created { get; set; }
        public decimal Price { get; set; }

        public int CustomerId { get; set; }           // связь с Покупателем через виртуальное свойство
        public virtual Customer Customer { get; set; }

        public int SellerId { get; set; }           // связь с Продовцом через виртуальное свойство
        public virtual Seller Seller { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }
        
        public override string ToString()
        {
            return $"№{CheckId} от {Created.ToString("dd.MM.yy hh:mm:ss")}";
        }

    }
}
