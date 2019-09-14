using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.HeadToHead.Dtos;
using ReadModel.Features.Matches.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using ReadModel.Features.Tournaments.Queries;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Features.HeadToHead.Queries
{
    public class GetHeadToHeadTournamentScheduleHandler : IRequestHandler<GetHeadToHeadTournamentSchedule,
        HeadToHeadTournamentScheduleReadDto>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetHeadToHeadTournamentScheduleHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HeadToHeadTournamentScheduleReadDto> Handle(GetHeadToHeadTournamentSchedule request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournamentId = request.TournamentId;

            var tournamentWithScheduleInfo = await _context
                .HeadToHeadTournaments
                .FetchWithScheduleInfo(FetchMode.ForRead)
                .WithIdAsync(tournamentId, cancellationToken);

            var tournamentInfo = _mapper.Map<HeadToHeadTournamentInfoReadDto>(tournamentWithScheduleInfo);
            var tours = tournamentWithScheduleInfo.Tours;

            var tournamentSchedules = tours.Select(t => new HeadToHeadTourScheduleReadDto(
                _mapper.Map<HeadToHeadTourInfoReadDto>(t),
                _mapper.Map<IEnumerable<HeadToHeadMatchInfoReadDto>>(t.Matches)));

            return new HeadToHeadTournamentScheduleReadDto(tournamentInfo, tournamentSchedules);
        }
    }
}