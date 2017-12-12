using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Predictions.Persistence;

namespace Predictions.WebApi.Controllers
{

    [Route ("api/[controller]")]
    public class ValuesController : Controller
    {
        private PredictionsContext _context;

        public ValuesController (PredictionsContext context)
        {
            _context = context;
        }

        // GET api/values

        [HttpGet]
        public IEnumerable<string> Get ()
        {
            return _context.Experts.Select (e => e.Nickname.ToString ()).ToList ();
        }

        // GET api/values/5

        [HttpGet ("{id}")]
        public string Get (int id)
        {
            return "value";
        }

        // POST api/values

        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5

        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5

        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}