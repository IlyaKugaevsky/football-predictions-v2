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
    public class GetScheduleHandler : IRequestHandler<GetSchedule, TournamentScheduleDto>
    {
        private readonly PredictionsContext _context;

        public GetScheduleHandler(PredictionsContext context)
        {
            _context = context;
        }

        public async Task<TournamentScheduleDto> Handle(GetSchedule request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournamentWithScheduleInfo =
                await _context.Tournaments
                    .FetchWithScheduleInfo()
                    .AsNoTracking()
                    .LastStartedAsync();

            var tournamentInfo = Mapper.Map<TournamentInfoReadDto>(tournamentWithScheduleInfo);
            var tours = tournamentWithScheduleInfo.Tours;

            var tournamentSchedules = tours.Select(t => new TourScheduleReadDto(
                Mapper.Map<TourInfoReadDto>(t),
                Mapper.Map<IEnumerable<MatchInfoReadDto>>(t.Matches)));

            return new TournamentScheduleDto(tournamentInfo, tournamentSchedules);
        }
    }
}