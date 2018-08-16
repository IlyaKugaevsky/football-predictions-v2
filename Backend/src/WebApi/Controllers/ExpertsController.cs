using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Experts.Queries;
using WriteModel.Features.Experts.Commands;
using WriteModel.Features.Experts.Dtos;
using WriteModel.Features.Tournaments.Commands;
using WriteModel.Features.Tournaments.Dtos;
using WriteModel.Features.Tours.Commands;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ExpertsController: Controller
    {
        private readonly IMediator _mediator;

        public ExpertsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/experts/
        [HttpGet]
        public async Task<IEnumerable<ExpertInfoReadDto>> GetExperts()
        {
            var getExperts = new GetExperts();
            return await _mediator.Send(getExperts);
        }

        // POST api/experts/
        [HttpPost()]
        public async Task<IActionResult> CreateExpert([FromBody] ExpertInfoWriteDto expertInfo)
        {
            var createExpert = new CreateExpert(expertInfo.Nickname);

            var isCompletedSuccessfully = await _mediator.Send(createExpert);

            if (isCompletedSuccessfully)
            {
                return Ok();
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // PATCH api/experts/:id
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateExpert(int id,
            [FromBody] ExpertInfoWriteDto expertInfo)
        {
            var updateExpert = new UpdateExpertInfo(id, expertInfo.Nickname);

            var isCompletedSuccessfully = await _mediator.Send(updateExpert);

            if (isCompletedSuccessfully)
            {
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/experts/:id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpert(int id,
            [FromBody] ExpertInfoWriteDto expertInfo)
        {
            var deleteExpert = new DeleteExpert(id);

            var isCompletedSuccessfully = await _mediator.Send(deleteExpert);

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