﻿using Core.Layers.DAL.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBasketRepository : IGenericRepository<Basket, string>
    {
    }
}
