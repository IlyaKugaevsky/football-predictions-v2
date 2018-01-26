using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReadModel.Features.Tournaments.Dtos;
using ReadModel.Features.Tournaments.Queries;
using WriteModel.Features.Tournaments.Dtos;
using WriteModel.Features.Tournaments.Commands;

namespace WebApi.Controllers
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
        [HttpGet]
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
        public async Task<TournamentScheduleDto> GetLatestTournamentSchedule()
        {
            var getSchedule = new GetSchedule();
            return await _mediator.Send(getSchedule);
        }

        // PATCH api/tournaments/:id
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, 
            [FromBody] TournamentInfoWriteDto tournamentInfo)
        {
            var UpdateTournament = new UpdateTournamentInfo(id, tournamentInfo.Title, 
                tournamentInfo.StartDate, tournamentInfo.EndDate);

            var isCompletedSuccessfully = await _mediator.Send(UpdateTournament);

            if (isCompletedSuccessfully) return Ok();
            else return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}