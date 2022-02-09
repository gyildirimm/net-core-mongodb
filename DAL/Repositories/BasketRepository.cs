using Core.Layers.DAL.Repositories.MongoDb;
using Core.Utilities.Extensions.Database;
using Core.Utilities.Settings;
using DAL.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BasketRepository : MongoBaseRepository<Basket>, IBasketRepository
    {
        private readonly IMongoCollection<Basket> _basketCollection;

        public BasketRepository(IOptions<MongoDbSetting> options) : base(options)
        {
            _basketCollection = options.Value.GetCollection<Basket>();
        }
    }
}
