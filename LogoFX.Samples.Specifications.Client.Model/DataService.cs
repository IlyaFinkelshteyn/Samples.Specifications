﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Core;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using LogoFX.Samples.Specifications.Client.Model.Mappers;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [UsedImplicitly]
    class DataService : ServiceBase, IDataService
    {
        private readonly IWarehouseProvider _warehouseProvider;        

        public DataService(IWarehouseProvider warehouseProvider)
        {
            _warehouseProvider = warehouseProvider;
        }

        private readonly RangeObservableCollection<IWarehouseItem> _warehouseItems = new RangeObservableCollection<IWarehouseItem>();
        IEnumerable<IWarehouseItem> IDataService.WarehouseItems
        {
            get { return _warehouseItems; }
        }

        public Task GetWarehouseItemsAsync()
        {
            return RunAsync(() =>
            {
                var warehouseItems =
                    _warehouseProvider.GetWarehouseItems().Select(WarehouseMapper.MapToWarehouseItem);
                _warehouseItems.Clear();
                _warehouseItems.AddRange(warehouseItems);
            });
        }
    }

    
}
