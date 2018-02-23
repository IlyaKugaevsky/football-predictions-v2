using System.Collections.Generic;
using System.Threading.Tasks;
using System;
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
        public async Task<IActionResult> GetTournaments()
        {
            var getTournaments = new GetTournaments();
            var tournaments = await _mediator.Send(getTournaments);

            return Ok(tournaments);
        }

        // GET api/tournaments/:id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTournament(int id)
        {
            var getTournament = new GetTournament(id);

            var tournament = await _mediator.Send(getTournament);

            if (tournament == null) return NotFound();
            else return Ok(tournament);
        }

        // GET api/tournaments/latest/schedule
        [HttpGet("latest/schedule")]
        public async Task<IActionResult> GetLatestTournamentSchedule()
        {
            var getSchedule = new GetSchedule();

            var schedule =  await _mediator.Send(getSchedule);

            return Ok(schedule);
        }

        // POST api/tournaments/
        [HttpPost()]
        public async Task<IActionResult> UpdateTournament(int id, 
            [FromBody] TournamentInfoWriteDto tournamentInfo)
        {
            var UpdateTournament = new UpdateTournamentInfo(id, tournamentInfo.Title, 
                tournamentInfo.StartDate, tournamentInfo.EndDate);

            var isCompletedSuccessfully = await _mediator.Send(UpdateTournament);

            if (isCompletedSuccessfully) return new StatusCodeResult(StatusCodes.Status201Created);
            else return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        // PATCH api/tournaments/:id
        [HttpPatch("{id}")]
        public async Task<IActionResult> CreateTournament([FromBody] TournamentInfoWriteDto tournamentInfo)
        {
            var UpdateTournament = new CreateTournament(tournamentInfo.Title, 
                tournamentInfo.StartDate, tournamentInfo.EndDate);

            var isCompletedSuccessfully = await _mediator.Send(UpdateTournament);

            if (isCompletedSuccessfully) return Ok();
            else return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        // DELETE api/tournaments/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id, 
            [FromBody] TournamentInfoWriteDto tournamentInfo)
        {
            var DeleteTournament = new DeleteTournament(id);

            var isCompletedSuccessfully = await _mediator.Send(DeleteTournament);

            if (isCompletedSuccessfully) return NoContent();
            else return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        // // POST api/tournaments/:id/tours
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> AddTours()
        // {
        // }


    }
}