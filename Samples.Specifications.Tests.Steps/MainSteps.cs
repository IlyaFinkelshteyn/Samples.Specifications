﻿using System;
using System.Linq;
using FluentAssertions;
using Samples.Specifications.Tests.Data;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public class MainSteps
    {
        private readonly IMainScreenObject _mainScreenObject;

        public MainSteps(IMainScreenObject mainScreenObject)
        {
            _mainScreenObject = mainScreenObject;
        }

        public void WhenISetThePriceForItemTo(string kind, int newPrice)
        {
            _mainScreenObject.EditWarehouseItem(kind, newPrice: newPrice);
        }

        public void WhenISetTheQuantityForItemTo(string kind, int newQuantity)
        {
            _mainScreenObject.EditWarehouseItem(kind, newQuantity: newQuantity);
        }

        public void WhenISetTheKindForItemTo(string kind, string newKind)
        {
            _mainScreenObject.EditWarehouseItem(kind, newKind: newKind);
        }

        public void ThenIExpectToSeeTheFollowingDataOnTheScreen(WarehouseItemAssertionTestData[] warehouseItems)
        {
            var actualWarehouseItems = _mainScreenObject.GetWarehouseItems().ToArray();
            for (int i = 0; i < Math.Max(warehouseItems.Length, actualWarehouseItems.Length); i++)
            {
                var expectedWarehouseItem = warehouseItems[i];
                var actualWarehouseItem = actualWarehouseItems[i];
                actualWarehouseItem.Kind.Should().Be(expectedWarehouseItem.Kind);
                actualWarehouseItem.Price.Should().Be(expectedWarehouseItem.Price);
                actualWarehouseItem.Quantity.Should().Be(expectedWarehouseItem.Quantity);
                actualWarehouseItem.TotalCost.Should().Be(expectedWarehouseItem.TotalCost);               
            }            
        }

        public void ThenTotalCostOfItemIs(string kind, int expectedTotalCost)
        {
            var actualWarehouseItem = _mainScreenObject.GetWarehouseItemByKind(kind);
            actualWarehouseItem.TotalCost.Should().Be(expectedTotalCost);
        }

        public void ThenApplicationNavigatesToTheMainScreen()
        {
            var isActive = _mainScreenObject.IsActive();
            isActive.Should().BeTrue();
        }

        public void WhenIDeleteItem(string kind)
        {
            _mainScreenObject.DeleteWarehouseItem(kind);
        }

        public void WhenICreateANewWarehouseItemWithTheFollowingData(WarehouseItemAssertionTestData[] warehouseItems)
        {
            warehouseItems.Should().HaveCount(1);

            foreach (var warehouseItem in warehouseItems)
            {
                _mainScreenObject.AddWarehouseItem(warehouseItem);
            }
        }

        public void ThenErrorMessageIsDisplayedWithTheFollowingText(string expectedErrorMessage)
        {
            var actualErrorMessage = _mainScreenObject.GetErrorMessage();
            actualErrorMessage.Should().Be(expectedErrorMessage);
        }

        public void WhenIDiscardTheChanges()
        {
            _mainScreenObject.DiscardChanges();
        }        
    }
}
