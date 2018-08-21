using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using ReadModel.Features.Experts.Dtos;

namespace ReadModel.Features.Experts.Queries
{
    public class GetIdByNicknameHandler: IRequestHandler<GetIdByNickname, int?>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetIdByNicknameHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int?> Handle(GetIdByNickname request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var expert = await _context.Experts.SingleOrDefaultAsync(e => e.Nickname == request.Nickname, cancellationToken);
            return expert?.Id;
        }
    }
}
