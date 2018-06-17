using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> CreateVehicleAsync([FromBody]VehicleResource vehicleResource)
        {
            var vehicle = Mapper.Map<VehicleResource, Vehicle>(vehicleResource);
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
    }
}