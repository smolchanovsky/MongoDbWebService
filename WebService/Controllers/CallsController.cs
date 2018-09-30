using BLL.Dto;
using Infrastructure.BLL;
using Infrastructure.WebApi;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
	[Route("api/[controller]")]
    public class CallsController : BaseController<CallDto>
    {
        public CallsController(IBaseService<CallDto> callService) : base(callService)
        {
            
        }
    }
}
