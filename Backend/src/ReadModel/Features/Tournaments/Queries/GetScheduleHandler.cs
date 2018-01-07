using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Predictions.Domain.Models;
using Predictions.Persistence;
using Predictions.Persistence.FetchExtensions;
using Predictions.Persistence.QueryExtensions;
using Predictions.ReadModel.Features.Tournaments.Dtos;
using Predictions.ReadModel.Features.Tours.Dtos;
using Predictions.ReadModel.Features.Matches.Dtos;

namespace Predictions.ReadModel.Features.Tournaments.Queries
{
    public class GetScheduleHandler : IRequestHandler<GetSchedule, TournamentScheduleReadDto>
    {
        private readonly PredictionsContext _context;

        public GetScheduleHandler(PredictionsContext context, IMediator mediator)
        {
            _context = context;
        }
        
        public async Task<TournamentScheduleReadDto> Handle(GetSchedule request,
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
            
            return new TournamentScheduleReadDto(tournamentInfo, tournamentSchedules);
        }
    }
}