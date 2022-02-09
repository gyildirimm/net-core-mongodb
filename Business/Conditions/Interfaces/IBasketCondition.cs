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
    public interface IBasketCondition
    {
        Task<IDataResult<BasketItem>> CheckItemStockControl(BasketActionDto action, BasketItem item = null);
    }
}
