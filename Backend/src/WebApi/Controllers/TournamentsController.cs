using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Metadata;
using MediatR;
using Predictions.Persistence;
using Predictions.Persistence.Entities;
using Predictions.ReadModel.Queries;
using Predictions.Persistence.EntityFrameworkExtensions;
using Predictions.Persistence.FetchExtensions;

namespace Predictions.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class TournamentsController : Controller
    {
        private PredictionsContext _context;
        private readonly IMediator _mediator;

        public TournamentsController(PredictionsContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET api/tournaments/

        [HttpGet()]
        public async Task<IEnumerable<Tournament>> GetTournaments()
        {
            var getTournaments = new GetTournaments();
            return await _mediator.Send(getTournaments);
        }        

        // GET api/tournaments/latest/schedule

        [HttpGet("latest/schedule")]
        public Tournament GetLatestTournamentSchedule()
        {
            return _context.Tournaments.WithScheduleInfo().OrderByDescending(t => t.StartDate).First();
        }
    }
}