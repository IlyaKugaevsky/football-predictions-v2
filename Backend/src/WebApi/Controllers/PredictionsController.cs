using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using ReadModel.Features.Predictions.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PredictionsController : Controller
    {
        private readonly IMediator _mediator;

        public PredictionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/predictions/
        [HttpGet]
        public async Task<IActionResult> GetAllPredictions()
        {
            var getPredictions = new GetPredictions();
            var predictions = await _mediator.Send(getPredictions);

            return Ok(predictions);
        }

        // GET api/predictions/tour/:tourId/expert/:expertId
        [HttpGet("tour/{tourId}/expert/{expertId}")]
        public async Task<IActionResult> GetPredictions(int tourId, int expertId)
        {
            var getPredictions = new GetPredictionsByTourAndExpert(tourId, expertId);
            var predictions = await _mediator.Send(getPredictions);

            return Ok(predictions);
        }




    }
}