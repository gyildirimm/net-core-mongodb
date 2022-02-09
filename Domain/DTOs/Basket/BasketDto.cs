using Core.Layers.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Basket
{
    public class BasketDto : MongoBaseDto
    {
        public string UserId { get; set; }

        public DiscountDto Discount { get; set; }

        public List<BasketItemDto> BasketItems { get; set; }

        public decimal TotalPrice
        {
            get => BasketItems.Sum(x => x.Money.UnitPrice * x.Quantity);
        }
    }

    public class DiscountDto
    {
        public string DiscountCode { get; set; }

        public int? DiscountRate { get; set; }
    }
}
