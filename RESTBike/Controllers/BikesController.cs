using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RESTBike.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTBike.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        //referance til Manager klassen
        //private BikesManager _manager;
        private readonly BikesManager _manager = new BikesManager();

        // GET: api/<ValuesController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Bike.Bike>> Get()
        {
            IEnumerable<Bike.Bike> result = _manager.GetAll();
            if (result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Bike.Bike> Get(int id)
        {
            Bike.Bike result = _manager.GetByID(id);
            if (result == null)
            {
                return NotFound("No such Bike, with ID" + id);
            }

            return Ok(result);
        }

        // POST api/<ValuesController>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Bike.Bike> Post([FromBody] Bike.Bike addBike)
        {
            Bike.Bike result = _manager.AddBike(addBike);
            if (result == null)
            {
                return null;
            }
            return Created($"/api/Bike/{result.Id}", result);
        }

        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Bike.Bike> Delete(int id)
        {
            Bike.Bike result = _manager.DeleteBike(id);
            if (result==null)
            {
                return NotFound("No such Bike with Id" + id);
            }
            return Ok(result);
        }
    }
}
