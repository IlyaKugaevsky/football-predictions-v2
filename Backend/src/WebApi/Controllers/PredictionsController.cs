using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;
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

        // GET api/predictions/tour/:tourId
        [HttpGet("tour/{tourId}")]
        public async Task<IActionResult> GetTourPredictions(int tourId)
        {
            var getTourPredictions = new GetTourPredictions(tourId);
            var predictions = await _mediator.Send(getTourPredictions);

            return Ok(predictions);
        }

        // GET api/predictions/tour/:tourId/text
        [HttpGet("tour/{tourId}/text")]
        public async Task<string> GetTourPredictionsAsText(int tourId)
        {
            var getTourPredictions = new GetTourPredictions(tourId);
            var predictions = await _mediator.Send(getTourPredictions);

            var sbuilder = new StringBuilder();

            foreach(var p in predictions)
            {
                sbuilder.Append($"{p.ToString()}{Environment.NewLine}");
            }

            return sbuilder.ToString();

            // return Ok(predictions.Select(p => p.ToString()).ToList());
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