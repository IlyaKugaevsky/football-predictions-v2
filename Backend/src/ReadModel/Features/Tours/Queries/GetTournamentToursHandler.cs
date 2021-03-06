﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence;
using ReadModel.Features.Tours.Dtos;
using Persistence.QueryExtensions;
using Persistence.FetchExtensions;

namespace ReadModel.Features.Tours.Queries
{
    public class GetTournamentToursHandler: IRequestHandler<GetTournamentTours, IEnumerable<TourInfoReadDto>>
    {
        private readonly PredictionsContext _context;
        private readonly IMapper _mapper;

        public GetTournamentToursHandler(PredictionsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourInfoReadDto>> Handle(GetTournamentTours request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var tournamentId = request.TournamentId;
            var tournament = await _context
                .Tournaments
                .FetchWithTours(FetchMode.ForRead)
                .WithIdAsync(tournamentId, cancellationToken);

            var tours = tournament.Tours;

            return _mapper.Map<IEnumerable<TourInfoReadDto>>(tours);
        }
    }
}
