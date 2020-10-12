using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehicleRentalWebApi.Data;
using VehicleRentalWebApi.Models;

namespace VehicleRentalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class VehicleRentalDBController<TEntity, TRepository> : ControllerBase
         where TEntity : class, IEntity
         where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;
        private readonly ILogger _logger;


        public VehicleRentalDBController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {      
            
                return await repository.GetAll(); 
            
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var vehicle = await repository.Get(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            await repository.Update(vehicle);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity vehicle)
        {
            await repository.Add(vehicle);
            return CreatedAtAction("Get", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var vehicle = await repository.Delete(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

    }
}
