using Microsoft.AspNetCore.Mvc;

namespace IntegraApi.Application.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
