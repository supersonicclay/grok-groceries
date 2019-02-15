using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrokGroceries.Data;
using Microsoft.AspNetCore.Mvc;

namespace GrokGroceries.Controllers
{

    [Route("v1/shopping-list")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private DataService data = DataService.Instance;

        [HttpGet]
        public ActionResult<ShoppingList> Get()
        {
            return data.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<ShoppingListEntry> AddEntry([FromBody] string name)
        {
            return Created(String.Empty, data.AddEntry(name));
        }

        [HttpPost("complete")]
        [ProducesResponseType(201)]
        public ActionResult<string> Complete([FromQuery] Guid uuid)
        {
            data.CompleteEntry(uuid);
            return Created(String.Empty, "done");
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
