﻿using System.Collections.Generic;
using System.Linq;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Tests.Data;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Client.Tests.Integration.Domain.ScreenObjects
{
    public class MainScreenObject : IMainScreenObject
    {
        public StructureHelper StructureHelper { get; }

        public MainScreenObject(StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
        }

        public bool IsActive()
        {
            var main = StructureHelper.GetMain();
            return main.IsActive;
        }

        public void AddWarehouseItem(WarehouseItemAssertionTestData warehouseItemData)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteWarehouseItem(string kind)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems()
        {
            var main = StructureHelper.GetMain();
            return main.WarehouseItems.WarehouseItems.OfType<WarehouseItemViewModel>()
                .Select(t => new WarehouseItemAssertionTestData
                {
                    Kind = t.Model.Kind,
                    Price = t.Model.Price,
                    Quantity = t.Model.Quantity,
                    TotalCost = t.Model.TotalCost
                });
        }

        public WarehouseItemAssertionTestData GetWarehouseItemByKind(string kind)
        {
            var main = StructureHelper.GetMain();
            return
                main.WarehouseItems.WarehouseItems.OfType<WarehouseItemViewModel>()
                    .Where(t => t.Model.Kind == kind)
                    .Select(t => new WarehouseItemAssertionTestData
                    {
                        Kind = t.Model.Kind,
                        Price = t.Model.Price,
                        Quantity = t.Model.Quantity,
                        TotalCost = t.Model.TotalCost
                    }).Single();
        }

        public void EditWarehouseItem(string kind, string newKind, double? newPrice, int? newQuantity)
        {
            var main = StructureHelper.GetMain();
            var itemViewModel =
                main.WarehouseItems.WarehouseItems
                    .OfType<WarehouseItemViewModel>().Single(t => t.Model.Kind == kind);

            if (newPrice != null)
            {
                itemViewModel.Model.Price = newPrice.Value;
            }

            if (newQuantity != null)
            {
                itemViewModel.Model.Quantity = newQuantity.Value;
            }
        }

        public string GetErrorMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}