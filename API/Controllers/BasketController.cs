using Business.Interfaces;
using Business.Validation;
using Core.Utilities.Filters.Validation;
using Core.Utilities.Wrappers;
using Domain.DTOs.Basket;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            this._basketService = basketService;
        }

        [HttpPost]
        [ValidationFilterAttribute(typeof(BasketActionValidator))]
        public async Task<IDataResult<BasketDto>> AddBasket(BasketActionDto action)
        {
            return await _basketService.AddBasket(action);
        }
    }
}
