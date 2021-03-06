﻿using System;
using System.Collections.Generic;
using Samples.Specifications.Server.Domain.Models;

namespace Samples.Specifications.Server.Domain.Services.Storage
{
    public interface IWarehouseRepository
    {
        WarehouseItem Add(WarehouseItem warehouseItem);
        IEnumerable<WarehouseItem> GetAll();
        WarehouseItem GetById(Guid id);
        void Delete(WarehouseItem warehouseItem);
        void Update(WarehouseItem warehouseItem);
    }
}
