using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMicroServices.Models;

namespace MyMicroServices.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        [Route("AddOrUpdateRated")]
        [HttpPost]
        public ActionResult<IList<ContractModel>> AddOrUpdateRated(IList<ContractModel> input)
        {
            return input.ToList();
        }
    }
}
