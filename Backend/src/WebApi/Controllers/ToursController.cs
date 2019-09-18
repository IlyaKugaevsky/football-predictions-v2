using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Features.Experts.Queries;
using ReadModel.Features.Tournaments.Queries;
using ReadModel.Features.Tours.Queries;
using WebApi.Helpers;
using WriteModel.Features.Predictions.Commands;
using WriteModel.Features.Teams.Dtos;
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
        private readonly TempData _tempData;

        public ToursController(IMediator mediator, TempData tempData)
        {
            _mediator = mediator;
            _tempData = tempData;
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

            return isCompletedSuccessfully ? NoContent() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
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

        // POST api/tours/:id/expert-predictions
        [HttpPost("{id}/expert-predictions")]
        public async Task<IActionResult> AddExpertPredictions(int id, 
            [FromBody] ExpertPredictionsWriteDto expertPredictions)
        {
            var nickname = expertPredictions.Nickname;
            var expertId = await _mediator.Send(new GetIdByNickname(nickname));

            if (expertId == null) return NotFound();

            _tempData.AddPrediction(expertPredictions);

            var addExpertTourPredictions =
                new AddExpertTourPredictions(expertId.Value, id, expertPredictions.Predictions);

            var isCompletedSuccessfully = await _mediator.Send(addExpertTourPredictions);


            if (isCompletedSuccessfully)
            {
                return Ok();
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/tours/adhoc
        [HttpGet("ad-hoc")]
        public IActionResult AdHoc()
        {
            return Ok(_tempData.GetPredictions());
        }


    }
}