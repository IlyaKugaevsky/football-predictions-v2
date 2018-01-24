using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReadModel.Features.Experts.Dtos;
using ReadModel.Features.Experts.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ExpertsController
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
    }
}