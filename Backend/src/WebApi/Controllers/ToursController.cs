using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MediatR;
using ReadModel.Features.Tours.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ToursController : Controller
    {
        private readonly IMediator _mediator;

        public ToursController(IMediator mediator)
        {
            _mediator = mediator;
        }

    }
}