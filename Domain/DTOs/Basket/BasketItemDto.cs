using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Basket
{
    public class BasketItemDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public MoneyDto Money { get; set; }

        public string PictureUrl { get; set; }
    }

    public class MoneyDto
    {
        public decimal UnitPrice { get; set; }

        public string Currency { get; set; }
    }
}
