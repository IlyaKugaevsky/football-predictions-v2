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
    public class GetScheduleHandler : IRequestHandler<GetSchedule, TournamentScheduleDto>
    {
        private readonly PredictionsContext _context;

        public GetScheduleHandler(PredictionsContext context, IMediator mediator)
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

            var tournamentInfo = Mapper.Map<TournamentInfoDto>(tournamentWithScheduleInfo);
            var tours = tournamentWithScheduleInfo.Tours;

            var tournamentSchedules = tours.Select(t => new TourScheduleDto(
                                        Mapper.Map<TourInfoDto>(t),
                                        Mapper.Map<IEnumerable<MatchInfoDto>>(t.Matches)));
            
            return new TournamentScheduleDto(tournamentInfo, tournamentSchedules);
        }
    }
}