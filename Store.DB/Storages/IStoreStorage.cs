﻿using Store.DB.Models;
using System.Threading.Tasks;

namespace Store.DB.Storages
{
    public interface IStoreStorage
    {
        ValueTask<City> CityInsert(City model);
    }
}