﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OfficeApi.Domain;
using OfficeApi.DTOs;
using OfficeApi.Interfaces;

namespace OfficeApi.Controllers
{
    [ApiController]
    [Route("api/office")]
    public class OfficeController(IOfficeRepository offRep, IMemoryCache cache) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OfficeDto officeDto, CancellationToken token)
        {
            var office = new Office()
            {
                City = officeDto.City,
                HouseNumber = officeDto.HouseNumber,
                OfficeNumber = officeDto.OfficeNumber,
                RegistryPhoneNumber = officeDto.RegistryPhoneNumber,
                Street = officeDto.Street,
                Status = officeDto.Status
            };

            return Ok(await offRep.CreateAsync(office, token));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromBody] OfficeDto officeDto, [FromRoute] Guid id, CancellationToken token)
        {
            var office = new Office()
            {
                Id = id,
                City = officeDto.City,
                HouseNumber = officeDto.HouseNumber,
                OfficeNumber = officeDto.OfficeNumber,
                RegistryPhoneNumber = officeDto.RegistryPhoneNumber,
                Street = officeDto.Street,
                Status = officeDto.Status
            };
            return Ok(await offRep.UpdateAsync(office, token));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            return Ok(await offRep.GetByIdAsync(id, token));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            IEnumerable<Office>? offices;
            if (cache.TryGetValue("GetAll", out offices))
                return Ok(offices.ToList());

            offices = await offRep.GetAllAsync(token);
            cache.Set("GetAll", offices);
            return Ok(offices.ToList());
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            await offRep.DeleteByIdAsync(id, token);
            return Ok();
        }
    }
}
