using Infrastructure.ServiceLayer;
using Infrastructure.WebApi;
using Microsoft.AspNetCore.Mvc;
using MongoDbWebService.ServiceLayer.Dto;

namespace MongoDbWebService.WebApi.Controllers
{
	[Route("api/[controller]")]
    public class CallsController : BaseController<CallDto>
    {
        public CallsController(IBaseService<CallDto> callService) : base(callService)
        {
            
        }
    }
}
