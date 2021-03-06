﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Domain.Services.Storage;
using Samples.Specifications.Server.Host.Data;
using Samples.Specifications.Server.Host.Mappers;

namespace Samples.Specifications.Server.Host.Controllers
{
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        
        [HttpGet]
        public IEnumerable<WarehouseItemDto> Get()
        {
            return _warehouseRepository.GetAll().Select(WarehouseMapper.MapToWarehouseItemDto);            
        }               
        
        [HttpPost]
        public void Post([FromBody]WarehouseItemDto warehouseItem)
        {
            _warehouseRepository.Add(WarehouseMapper.MapToWarehouseItem(warehouseItem));
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]WarehouseItemDto warehouseItem)
        {
            _warehouseRepository.Update(WarehouseMapper.MapToWarehouseItem(warehouseItem));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _warehouseRepository.GetById(id);
            _warehouseRepository.Delete(item);
            return Ok();
        }
    }
}