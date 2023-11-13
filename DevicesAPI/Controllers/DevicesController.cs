using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DevicesAPI.Data;
using DevicesAPI.Models;

namespace DevicesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly DevicesDb _dbContext;

        public DevicesController(DevicesDb dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("/devices")]
        public async Task<IActionResult> GetDevices()
        {
            var devices = await _dbContext.Devices.ToListAsync();
            //return await _dbContext.Devices.ToListAsync();
            return Ok(devices);
        }

        [HttpGet("/devices/{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            var device = await _dbContext.Devices.FindAsync(id);
            //return device is Devices ? Results.Ok(device) : Results.NotFound();
            if (device is Devices)
            {
                return Ok(device);
            }
            return NotFound();
        }

        [HttpPost("/devices")]
        public async Task<IActionResult> CreateDevice(Devices device)
        {
            _dbContext.Devices.Add(device);
            await _dbContext.SaveChangesAsync();
            //return Results.Created($"/devices/{device.id}", device);

            return Created($"/{device.id}", device);
            //return CreatedAtAction(nameof(GetDevice), new { id = device.id }, device);
        }

        [HttpPut("/devices/{id}")]
        public async Task<IActionResult> UpdateDevice(int id, Devices inputDevice)
        {
            var device = await _dbContext.Devices.FindAsync(id);

            if (device is null) return NotFound();

            if (!string.IsNullOrEmpty(inputDevice.description))
                device.description = inputDevice.description;

            if (!string.IsNullOrEmpty(inputDevice.adress))
                device.adress = inputDevice.adress;

            if (inputDevice.kWh_energy_consumption.HasValue && inputDevice.kWh_energy_consumption > 0)
                device.kWh_energy_consumption = inputDevice.kWh_energy_consumption;
            else
                device.kWh_energy_consumption = null;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("/devices/{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _dbContext.Devices.FindAsync(id);

            if (device is not null)
            {
                _dbContext.Devices.Remove(device);
                await _dbContext.SaveChangesAsync();
                //Console.WriteLine($"Deleted 1 item with id = {id}");

                return NoContent();
            }

            return NotFound();
        }
    }
}