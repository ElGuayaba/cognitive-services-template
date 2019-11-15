using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveServicesTemplate.Api.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        // GET: api/Ocr
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Ocr/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Ocr
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
