﻿using System.Collections.Generic;
using Samples.Client.Data.Contracts.Dto;

#if FAKE
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
#endif

#if REAL
using Samples.Specifications.Tests.Steps.Helpers;
#endif

namespace Samples.Specifications.Tests.Steps
{
    public class GivenMainSteps
    {
#if FAKE
        private readonly IBuilderRegistrationService _builderRegistrationService;
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;

        public GivenMainSteps(
            IBuilderRegistrationService builderRegistrationService,
            WarehouseProviderBuilder warehouseProviderBuilder)
        {
            _builderRegistrationService = builderRegistrationService;
            _warehouseProviderBuilder = warehouseProviderBuilder;
        }
#endif
        public void SetupWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
#if FAKE
            _warehouseProviderBuilder.WithWarehouseItems(warehouseItems);
            _builderRegistrationService.RegisterBuilder(_warehouseProviderBuilder);
#endif

#if REAL
            var repository = new DbSetupHelper();
            repository.Clear();
            foreach (var warehouseItemDto in warehouseItems)
            {
                repository.Add(warehouseItemDto);
            }

            //using (var storage = new Storage())
            //{
            //    foreach (var warehouseItem in warehouseItems)
            //    {
            //        storage.Store(warehouseItem);
            //    }
            //}
#endif
        }
    }
}
