using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Features.Tournaments.Queries;
using ReadModel.Features.Tours.Queries;
using WriteModel.Features.Tournaments.Commands;
using WriteModel.Features.Tournaments.Dtos;
using WriteModel.Features.Tours.Commands;
using WriteModel.Features.Tours.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ToursController : Controller
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly IMediator _mediator;

        public ToursController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // PATCH api/tours/:id
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTour(int id,
            [FromBody] TourInfoWriteDto tourInfo)
        {
            var updateTour = new UpdateTourInfo(id, tourInfo.Number,
                tourInfo.StartDate, tourInfo.EndDate);

            var isCompletedSuccessfully = await _mediator.Send(updateTour);

            if (isCompletedSuccessfully)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/tours/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(int id,
            [FromBody] TourInfoWriteDto tourInfo)
        {
            var deleteTour = new DeleteTour(id);

            var isCompletedSuccessfully = await _mediator.Send(deleteTour);

            if (isCompletedSuccessfully)
            {
                return NoContent();
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }



        // GET api/tours/incoming
        [HttpGet("incoming")]
        public async Task<IActionResult> GetIncomingTour()
        {
            var getIncomingTour = new GetIncomingTour();

            var tour = await _mediator.Send(getIncomingTour);

            if (tour == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tour);
            }
        }

    }
}