﻿using System;

namespace Samples.Specifications.Server.Domain.Models
{
    public class WarehouseItem
    {
        public Guid Id { get; set; }
        public string Kind { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
