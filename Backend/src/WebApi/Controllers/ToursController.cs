using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApi.Controllers
{
    public class ToursController
    {
        private readonly IMediator _mediator;

        public ToursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/tournaments/:id/tours
        [HttpGet]
        public async Task<IActionResult> GetTournamentTours()
        {
            throw new NotImplementedException();
        }
    }
}