using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using MediatR;
using Persistence;
using Persistence.FetchExtensions;
using Persistence.QueryExtensions;
using ReadModel.Features.HeadToHead.Dtos;

namespace ReadModel.Features.HeadToHead.Queries
{
    public class GetHeadToHeadTableHandler : IRequestHandler<GetHeadToHeadTable,
        HeadToHeadTableReadDto>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetHeadToHeadTableHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HeadToHeadTableReadDto> Handle(GetHeadToHeadTable request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournamentId = request.HeadToHeadTournamentId;

            var tournamentWithScheduleInfo = await _context
                .HeadToHeadTournaments
                .FetchWithScheduleInfo(FetchMode.ForRead)
                .WithIdAsync(tournamentId, cancellationToken);

            var parentTournament = tournamentWithScheduleInfo.ParentTournament;
            
            var tours = tournamentWithScheduleInfo.Tours.ToList();


            const int toursNumber = 7;
            var tableProcessor = new LeagueTableProcessor("test trnm");

            for (var i = 0; i < toursNumber; i++)
            {
                var testTour = tours.ToList()[i];

                var headToHeadMatches = testTour.Matches;

                

                foreach (var headToHeadMatch in headToHeadMatches)
                {
                    var homeExpertNickname = headToHeadMatch.HomeExpert.Nickname;
                    var awayExpertNickname = headToHeadMatch.AwayExpert.Nickname;

                    var homeGoals = headToHeadMatch.HomeGoals;
                    var awayGoals = headToHeadMatch.AwayGoals;
                
                    tableProcessor.HandleMatch(homeExpertNickname, homeGoals, awayExpertNickname, awayGoals);
                }
            }

            var table = tableProcessor.Table;
            var tableLines = table.Select(line => new HeadToHeadTableLineReadDto(line.Key, line.Value)).OrderBy(line => line.Points).ThenBy(lines => lines.ScoredGoals - lines.ConcededGoals).ToList();

            return new HeadToHeadTableReadDto("test trnm", tableLines);
        }
    }
}