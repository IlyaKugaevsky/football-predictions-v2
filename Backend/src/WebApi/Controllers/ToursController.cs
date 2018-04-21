using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ToursController : Controller
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly IMediator _mediator;

        public ToursController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}