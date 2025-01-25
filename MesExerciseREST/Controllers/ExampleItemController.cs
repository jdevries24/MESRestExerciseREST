using MesExerciseREST.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MesExerciseREST.Controllers
{
    [ApiController]
    [Route("apiv1")]
    public class ExampleItemController : Controller
    {
        InterfaceBase _interface;
        public ExampleItemController(SqliteInterface LiteInterface,EntitiyFrameworkInterface EntryInterface)
        {
            _interface = EntryInterface;
        }

        [Route("GetItemByKey/{key}")]
        [HttpGet]
        public ActionResult<ExampleItem> GetItemByKey(string key)
        {
            if (_interface.DoesItemExist(key))
            {
                return Ok(_interface.GetItem(key));
            }
            else
            {
                return BadRequest("Item does not exist");
            }
        }

        [Route("SearchItemsByValue/{value}")]
        [HttpGet]
        public ActionResult<IEnumerable<ExampleItem>> SearchItemsByValue(string value)
        {
            return Ok(_interface.SearchItemsByValue(value));
        }

        [HttpPost("NewItem")]
        public ActionResult<ExampleItem> NewItem(ExampleItem NewItem)
        {
            if (_interface.DoesItemExist(NewItem.Key))
            {
                return BadRequest("Item with key already exsits");
            }
            else
            {
                _interface.AddItem(NewItem);
                return Ok(_interface.GetItem(NewItem.Key));
            }
        }

        [HttpPut("UpdateItem")]
        public ActionResult<ExampleItem> UpdateItem(ExampleItem ItemToUpdate)
        {
            if (_interface.DoesItemExist(ItemToUpdate.Key))
            {
                _interface.UpdateItem(ItemToUpdate);
                return Ok(_interface.GetItem(ItemToUpdate.Key));
            }
            else
            {
                return BadRequest("Item doesn't exist");
            }
        }

        [Route("DeleteItem/{key}")]
        [HttpDelete]
        public ActionResult DeleteItem(string key)
        {
            if (_interface.DoesItemExist(key))
            {
                _interface.DeleteItem(key);
                return Ok();
            }
            else
            {
                return BadRequest("Item Doesnt exist");
            }
        }
    }
}
