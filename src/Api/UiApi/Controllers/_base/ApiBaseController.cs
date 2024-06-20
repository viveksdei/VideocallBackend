using MediatR;

namespace UiApi.Controllers._base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : Controller
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
