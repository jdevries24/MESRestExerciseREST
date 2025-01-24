using MesExerciseREST.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MesExerciseREST.Controllers
{
    [ApiController]
    [Route("apiv1")]
    public class ExampleItemController : Controller
    {
        InterfaceBase _interface;
        public ExampleItemController(EntitiyFrameworkInterface inter)
        {
            _interface = inter;
        }

        [Route("GetItemByKey/{key}")]
        [HttpGet]
        public ActionResult<ExampleItem> GetItemByKey(string key)
        {
            return Ok(_interface.GetItem(key));
        }

        [Route("SerchItemsByValue/{value}")]
        [HttpGet]
        public ActionResult<IEnumerable<ExampleItem>> SearchItemsByValue(string value)
        {
            throw new NotImplementedException();
        }

        [HttpPost("NewItem")]
        public ActionResult<ExampleItem> NewItem(ExampleItem NewItem)
        {
            _interface.AddItem(NewItem);
            return Ok(_interface.GetItem(NewItem.Key));
        }

        [HttpPut("UpdateItem")]
        public ActionResult<ExampleItem> UpdateItem(ExampleItem ItemToUpdate)
        {
            _interface.UpdateItem(ItemToUpdate);
            return Ok(_interface.GetItem(ItemToUpdate.Key));
        }

        [Route("DeleteItem/{key}")]
        [HttpDelete]
        public ActionResult DeleteItem(string key)
        {
            throw new NotImplementedException();
        }
    }
}
