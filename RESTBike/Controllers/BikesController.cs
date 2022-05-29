using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RESTBike.Managers;


namespace RESTBike.Controllers
{
    /// <summary>
    /// a controller is a class that handles HTTP requests. 
    /// The public methods of the controller are called action methods 
    /// When the Web API framework receives a request, it routes the request 
    /// to an action.
    /// </summary>
    
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        //referance til Manager klassen
        //private BikesManager _manager;
        private readonly BikesManager _manager = new BikesManager();

        // GET: api/<bikesController>
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

        // GET api/<bikesController>/5
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

        //PUT api/<bikesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Bike.Bike> Put(int id, [FromBody] Bike.Bike updateBike)
        {
            Bike.Bike result = _manager.UpdateBike(id, updateBike);
            if (result == null)
            {
                return NotFound("No such bike, with ID: " + id);
            }
            //ellers
            return Ok(result);
        }

        // DELETE api/<bikesController>/5
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
