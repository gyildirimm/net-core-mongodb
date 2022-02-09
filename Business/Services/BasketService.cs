using Business.Conditions;
using Business.Interfaces;
using Business.Validation;
using Core.Utilities.Filters.Validation;
using Core.Utilities.Helpers.Auth;
using Core.Utilities.Helpers.Business;
using Core.Utilities.Wrappers;
using DAL.Interfaces;
using DAL.Mapping;
using Domain.DTOs.Basket;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ISharedIdentityHelper _identityHelper;
        private readonly IBasketCondition _basketCondition;

        public BasketService(
            IBasketRepository basketRepository,
            ISharedIdentityHelper identityHelper,
            IBasketCondition basketCondition
            )
        {
            this._basketRepository = basketRepository;
            this._identityHelper = identityHelper;
            this._basketCondition = basketCondition;
        }

        public async Task<IDataResult<BasketDto>> AddBasket(BasketActionDto action)
        {
            Basket basket = await GetBasketAsync();

            basket = await SetAddStockBasket(basket, action);

            basket = await ControlActions(basket, action);

            var repositoryResponse = basket.Id == null
                ? await _basketRepository.AddAsync(basket)
                : await _basketRepository.UpdateAsync(basket);

            return new SuccessDataResult<BasketDto>(ObjectMapper.Mapper.Map<BasketDto>(repositoryResponse), 200);
        }
 
        private async Task<Basket> GetBasketAsync()
        {
            string userId = "userIdddd"; //_identityHelper.GetUserId;

            var basket = await _basketRepository.GetAsync(w => w.UserId.Equals(userId));

            if (basket == null)
            {
                basket = new Basket()
                {
                    UserId = userId,
                    BasketItems = new List<BasketItem>()
                };
            }

            return basket;
        }

        private async Task<Basket> SetAddStockBasket(Basket basket, BasketActionDto action)
        {
            var selectedBasketItem = basket.BasketItems.FirstOrDefault(w => w.ProductId == action.ProductId);

            var control = await _basketCondition.CheckItemStockControl(action, selectedBasketItem);

            int listIndex = basket.BasketItems.FindIndex(w => w.ProductId == action.ProductId);

            if (listIndex != -1)
                basket.BasketItems[listIndex] = selectedBasketItem;
            else
                basket.BasketItems.Add(control.Data);

            return basket;
        }

        private async Task<Basket> ControlActions(Basket basket, BasketActionDto action)
        {

            // Run All Conditions example => BusinessRules.Run(_basketCondition.ControlMethods())

            return basket;
        }
    }
}
