using Core.Layers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Basket : MongoBaseEntity
    {
        public string UserId { get; set; }

        public Discount Discount { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }

    public class Discount
    {
        public string DiscountCode { get; set; }

        public int? DiscountRate { get; set; }
    }
}
