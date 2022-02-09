using Core.Utilities.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Basket;
using Domain.Entities;

namespace Business.Interfaces
{
    public interface IBasketService
    {
        Task<IDataResult<BasketDto>> AddBasket(BasketActionDto action);
    }
}
