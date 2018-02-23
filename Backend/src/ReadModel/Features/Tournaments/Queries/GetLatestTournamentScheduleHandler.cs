using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.XpressionMapper.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.Matches.Dtos;
using ReadModel.Features.Tournaments.Dtos;
using ReadModel.Features.Tours.Dtos;

namespace ReadModel.Features.Tournaments.Queries
{
    public class GetLatestTournamentScheduleHandler : IRequestHandler<GetLatestTournamentSchedule, TournamentScheduleDto>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetLatestTournamentScheduleHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TournamentScheduleDto> Handle(GetLatestTournamentSchedule request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournamentWithScheduleInfo =
                await _context.Tournaments
                    .FetchWithScheduleInfo()
                    .AsNoTracking()
                    .LastStartedAsync();

            var tournamentInfo = _mapper.Map<TournamentInfoReadDto>(tournamentWithScheduleInfo);
            var tours = tournamentWithScheduleInfo.Tours;

            var tournamentSchedules = tours.Select(t => new TourScheduleReadDto(
                _mapper.Map<TourInfoReadDto>(t),
                _mapper.Map<IEnumerable<MatchInfoReadDto>>(t.Matches)));

            return new TournamentScheduleDto(tournamentInfo, tournamentSchedules);
        }
    }
}