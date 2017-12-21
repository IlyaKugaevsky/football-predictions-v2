using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Metadata;
using MediatR;
using AutoMapper;
using Predictions.Persistence;
using Predictions.ReadModel.Queries;
using Predictions.ReadModel.Dtos;
using Predictions.Persistence.EntityFrameworkExtensions;
using Predictions.Persistence.FetchExtensions;
using Predictions.Domain.Models;

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
        public async Task<IEnumerable<TournamentInfoDto>> GetTournaments()
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