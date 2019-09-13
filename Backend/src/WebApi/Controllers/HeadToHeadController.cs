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
        private IMediator _mediator;
        
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
    }
}