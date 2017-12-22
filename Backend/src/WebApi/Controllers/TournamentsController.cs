using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Predictions.ReadModel.Features.Tournaments.Dtos;
using Predictions.ReadModel.Features.Tournaments.Queries;

namespace Predictions.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TournamentsController : Controller
    {
        private readonly IMediator _mediator;

        public TournamentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/tournaments/

        [HttpGet()]
        public async Task<IEnumerable<TournamentInfoReadDto>> GetTournaments()
        {
            var getTournaments = new GetTournaments();
            return await _mediator.Send(getTournaments);
        }

        // GET api/tournaments/:id

        [HttpGet("{id}")]
        public async Task<TournamentInfoReadDto> GetTournamentint(int id)
        {
            var getTournament = new GetTournament(id);
            return await _mediator.Send(getTournament);
        }        

        // GET api/tournaments/latest/schedule

        [HttpGet("latest/schedule")]
        public async Task<TournamentScheduleReadDto> GetLatestTournamentSchedule()
        {
            var getSchedule = new GetSchedule();
            return await _mediator.Send(getSchedule);

        }
    }
}