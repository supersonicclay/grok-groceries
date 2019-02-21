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
            if (String.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Must supply a name");
            }
            return Created(String.Empty, data.AddEntry(name));
        }

        [HttpPost("complete")]
        [ProducesResponseType(201)]
        public ActionResult<string> Complete([FromQuery] Guid uuid)
        {
            data.CompleteEntry(uuid);
            return Created(String.Empty, "done");
        }

        [HttpPost("uncomplete")]
        [ProducesResponseType(201)]
        public ActionResult<string> Uncomplete([FromQuery] Guid uuid)
        {
            data.UncompleteEntry(uuid);
            return Created(String.Empty, "done");
        }

        [HttpPost("clear-completed")]
        [ProducesResponseType(201)]
        public ActionResult<string> ClearCompleted()
        {
            data.ClearCompletedEntries();
            return Created(String.Empty, "done");
        }

    }
}
