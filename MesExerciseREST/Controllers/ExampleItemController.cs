using MesExerciseREST.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MesExerciseREST.Controllers
{
    [ApiController]
    [Route("apiv1")]
    public class ExampleItemController : Controller
    {
        //Rather then the API directly interfacing with the Database a interface class is used.
        InterfaceBase _interface;
        public ExampleItemController(SqliteInterface LiteInterface,EntitiyFrameworkInterface EntryInterface)
        {
            //for setting what version of the interface to be used should be done via appsettings.
            //this is a todo item for now will simply comment out what interface not to use
            _interface = LiteInterface;
            // _interface = EntryInterface;
        }

        [Route("GetItemByKey/{key}")]
        [HttpGet]
        public ActionResult<ExampleItem> GetItemByKey(string key)
        {
            //the API is responsible for ensuring that a requst is good before throwing it down to the interface
            //this is done because the API needs to inform the end user of any errors. 
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
            //No error handeling here as there will always be some result
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
