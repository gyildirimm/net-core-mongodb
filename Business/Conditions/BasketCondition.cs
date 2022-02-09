using Core.Utilities.Wrappers;
using Domain.DTOs.Basket;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Conditions
{
    public class BasketCondition : IBasketCondition
    {
        public async Task<IDataResult<BasketItem>> CheckItemStockControl(BasketActionDto action, BasketItem item = null)
        {

            if(item != null) 
                action.Quantity += item.Quantity;

            //var Request = await ProductService.Control(action);

            if(item != null)
            {
                item.Quantity = action.Quantity;
            }else
            {
                item = new BasketItem()
                {
                    ProductId = action.ProductId,
                    Quantity = action.Quantity,
                    PictureUrl = "examplePicture",
                    ProductName = "exampleProductName",
                    Money = new Money() { UnitPrice = 50, Currency = "TL"}
                };
            }

            return new SuccessDataResult<BasketItem>(item);
        }
    }
}
