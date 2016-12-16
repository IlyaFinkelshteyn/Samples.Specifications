﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Attest.Fake.Builders;
using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;
using Samples.Specifications.Client.Data.Fake.Containers;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.Scheduling;

namespace Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class FakeWarehouseProvider : FakeProviderBase<WarehouseProviderBuilder, IWarehouseProvider>, IWarehouseProvider
    {
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;
        private readonly Random _random = new Random();

        public FakeWarehouseProvider(
            WarehouseProviderBuilder warehouseProviderBuilder,
            IWarehouseContainer warehouseContainer)
        {
            _warehouseProviderBuilder = warehouseProviderBuilder;
            _warehouseProviderBuilder.WithWarehouseItems(warehouseContainer.WarehouseItems);
        }

        async Task<IEnumerable<WarehouseItemDto>> IWarehouseProvider.GetWarehouseItems()
        {
            await Task.Delay(_random.Next(2000));
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            var warehouseItems = await service.GetWarehouseItems();
            return warehouseItems;
        }

        async Task<bool> IWarehouseProvider.DeleteWarehouseItem(Guid id)
        {
            await Task.Delay(_random.Next(2000));
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            var retVal = await service.DeleteWarehouseItem(id);
            return retVal;
        }

        async Task IWarehouseProvider.SaveWarehouseItem(WarehouseItemDto dto)
        {
            await Task.Delay(_random.Next(2000));
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            await service.SaveWarehouseItem(dto);
        }
    }
}