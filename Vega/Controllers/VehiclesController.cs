using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Controllers.Resources;
using Vega.Models;
using Vega.Persistence;

namespace Vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        public VegaDbContext Context { get; }
        public IMapper Mapper { get; }

        public VehiclesController(VegaDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await Context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var vehicleResource = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vehicleResource);
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync([FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = Mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;
            try
            {
                await Context.Vehicles.AddAsync(vehicle);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.InnerException?.Message ?? ex.Message);
            }


            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleAsync(int id, [FromBody]VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await Context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            Mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdatingException", ex.InnerException?.Message ?? ex.Message);
                return BadRequest(ModelState);
            }


            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await Context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            Context.Remove(vehicle);
            await Context.SaveChangesAsync();

            return Ok(id);
        }
    }
}