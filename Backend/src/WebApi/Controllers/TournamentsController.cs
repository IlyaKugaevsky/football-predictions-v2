using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReadModel.Features.Tournaments.Queries;
using WriteModel.Features.Tournaments.Dtos;
using WriteModel.Features.Tournaments.Commands;
using ReadModel.Features.Tours.Queries;
using WriteModel.Features.Tours.Dtos;

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
        public async Task<IActionResult> GetAllTournaments()
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

            if (tournament == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tournament);
            }
        }

        // GET api/tournaments/latest/schedule
        [HttpGet("latest/schedule")]
        public async Task<IActionResult> GetLatestTournamentSchedule()
        {
            var getLatestTournamentSchedule = new GetLatestTournamentSchedule();

            var schedule =  await _mediator.Send(getLatestTournamentSchedule);

            return Ok(schedule);
        }

        // GET api/tournaments/:id/tours
        [HttpGet("{id}/tours")]
        public async Task<IActionResult> GetTournamentTours(int id)
        {
            var getTournamentTours = new GetTournamentTours(id);
            var tours = await _mediator.Send(getTournamentTours);

            if (tours == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tours);
            }
        }

        // GET api/tournaments/:id/tours/:number/
        [HttpGet("{id}/tours/{number}/expert-stats")]
        public async Task<IActionResult> GetExpertStats(int id, int number)
        {
            var getExpertStats = new GetExpertStats(id, number);
            var expertStats = await _mediator.Send(getExpertStats);

            return Ok(expertStats);
        }

        // POST api/tournaments/
        [HttpPost()]
        public async Task<IActionResult> CreateTournament([FromBody] TournamentInfoWriteDto tournamentInfo)
        {
            var createTournament = new CreateTournament(tournamentInfo.Title,
                tournamentInfo.StartDate, tournamentInfo.EndDate);

            var isCompletedSuccessfully = await _mediator.Send(createTournament);

            if (isCompletedSuccessfully)
            {
                return Ok();
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/tournaments/:id/tours
        [HttpPost("{id}/tours")]
        public async Task<IActionResult> AddTours(int tournamentId, [FromBody] IEnumerable<TourInfoWriteDto> tours)
        {
            var addTours = new AddTours(tournamentId, tours);

            var isCompletedSuccessfully = await _mediator.Send(addTours);

            if (isCompletedSuccessfully)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PATCH api/tournaments/:id
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTournament(int id,
            [FromBody] TournamentInfoWriteDto tournamentInfo)
        {
            var updateTournament = new UpdateTournamentInfo(id, tournamentInfo.Title,
                tournamentInfo.StartDate, tournamentInfo.EndDate);

            var isCompletedSuccessfully = await _mediator.Send(updateTournament);

            if (isCompletedSuccessfully)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/tournaments/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id, 
            [FromBody] TournamentInfoWriteDto tournamentInfo)
        {
            var deleteTournament = new DeleteTournament(id);

            var isCompletedSuccessfully = await _mediator.Send(deleteTournament);

            if (isCompletedSuccessfully)
            {
                return NoContent();
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


    }
}