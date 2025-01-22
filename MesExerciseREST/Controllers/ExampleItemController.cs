using Microsoft.AspNetCore.Mvc;

namespace MesExerciseREST.Controllers
{
    [ApiController]
    [Route("apiv1")]
    public class ExampleItemController : Controller
    {
        [Route("GetItemByKey/{key}")]
        [HttpGet]
        public ActionResult<ExampleItem> GetItemByKey(string key)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [HttpPut("UpdateItem")]
        public ActionResult<ExampleItem> UpdateItem(ExampleItem ItemToUpdate)
        {
            throw new NotImplementedException();
        }

        [Route("DeleteItem/{key}")]
        [HttpDelete]
        public ActionResult DeleteItem(string key)
        {
            throw new NotImplementedException();
        }
    }
}
