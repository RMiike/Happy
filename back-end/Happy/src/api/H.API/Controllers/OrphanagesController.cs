using H.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace H.API.Controllers
{
    public class OrphanagesController : BaseController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public OrphanageModel Get(int id)
        {
            return new OrphanageModel();
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrphanageModel orphanageModel)
        {
            return CustomResponse();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
