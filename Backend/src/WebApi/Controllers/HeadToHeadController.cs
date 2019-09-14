using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Features.HeadToHead.Queries;
using ReadModel.Features.Predictions.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class HeadToHeadController: Controller
    {
        private readonly IMediator _mediator;
        
        public HeadToHeadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // GET api/headtohead/tournaments/
        [HttpGet("tournaments")]
        public async Task<IActionResult> GetAllPredictions()
        {
            var getTournaments = new GetHeadToHeadTournaments();
            var tournaments = await _mediator.Send(getTournaments);

            return Ok(tournaments);
        }
        
        // GET api/headtohead/matches/
        [HttpGet("matches")]
        public async Task<IActionResult> GetAllMatches()
        {
            var getMatches = new GetHeadToHeadMatches();
            var matches = await _mediator.Send(getMatches);

            return Ok(matches);
        }
        
        // GET api/headtohead/tours/
        [HttpGet("tours")]
        public async Task<IActionResult> GetAllTours()
        {
            var getHeadToHeadTours = new GetHeadToHeadTours();
            var tours = await _mediator.Send(getHeadToHeadTours);

            return Ok(tours);
        }
    }
}