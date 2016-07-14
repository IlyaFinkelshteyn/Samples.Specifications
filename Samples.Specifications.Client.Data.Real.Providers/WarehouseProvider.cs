﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    class WarehouseProvider : IWarehouseProvider
    {
        public Task<IEnumerable<WarehouseItemDto>> GetWarehouseItems()
        {
            //put here real data logic
            return Task.FromResult((IEnumerable<WarehouseItemDto>) new[]
            {
                new WarehouseItemDto
                {
                    Kind = "Acme",
                    Price = 10,
                    Quantity = 10
                }
            });           
        }
    }
}