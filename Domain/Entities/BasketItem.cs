using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BasketItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public Money Money { get; set; }

        public string PictureUrl { get; set; }
    }

    public class Money
    {
        public decimal UnitPrice { get; set; }

        public string Currency { get; set; }
    }
}
