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
        private ShoppingList list = ShoppingList.Instance;

        [HttpGet]
        public ActionResult<IEnumerable<ShoppingListEntry>> Get()
        {
            return list.GetAll();
        }

        [HttpPost]
        public ActionResult<ShoppingListEntry> AddEntry([FromBody] string name)
        {
            return list.AddEntry(name);
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
