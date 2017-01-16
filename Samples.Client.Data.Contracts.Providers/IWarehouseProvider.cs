﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.Client.Data.Contracts.Dto;

namespace Samples.Client.Data.Contracts.Providers
{
    public interface IWarehouseProvider
    {
        Task<IEnumerable<WarehouseItemDto>> GetWarehouseItems();
        Task<bool> DeleteWarehouseItem(Guid id);
        void SaveWarehouseItem(WarehouseItemDto dto);        
    }
}
