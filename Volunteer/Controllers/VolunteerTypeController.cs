using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;
using System.Net;
using System.IO;

using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using GoogleApi.Entities.Maps.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerTypeController : ControllerBase
    {
        IVolunteerTypeBL volunteertypebl;
        public VolunteerTypeController(IVolunteerTypeBL volunteertypebl)
        {
            this.volunteertypebl = volunteertypebl;
        }
        // GET: api/<VolunteerTypeController>
        [HttpGet]
        public Task<List<VolunteerType>> Get()
        {
            return this.volunteertypebl.getVolunteerTypes();
        }

        // GET api/<VolunteerTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VolunteerTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VolunteerTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VolunteerTypeController>/5
        [HttpDelete("{id}")]
        public Distance Delete(int id)
        {
            string origion = "הר נוף";
            string destination = "בית וגן";
            Address aOrigion = new Address(origion);
            Address aDestination = new Address(destination);

            LocationEx origionlx = new LocationEx(aOrigion);
            LocationEx destinationlx = new LocationEx(aDestination);

            DirectionsRequest request = new DirectionsRequest();

            request.Key = "AIzaSyBHO2BM3GPRMdYEajDEy9hph9GESt8bXrA";
            request.Origin = origionlx;
            request.Destination = destinationlx;

            var response = GoogleApi.GoogleMaps.Directions.Query(request);
            return response.Routes.First().Legs.First().Distance;


        }

    }
}

