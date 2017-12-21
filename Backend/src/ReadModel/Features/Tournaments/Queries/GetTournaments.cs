using System;
using System.Collections.Generic;
using System.Linq;
using Predictions.Persistence;
using Predictions.Domain.Models;
using Predictions.ReadModel.Features.Tournaments.Dtos;
using MediatR;

namespace Predictions.ReadModel.Features.Tournaments.Queries
{
    public class GetTournaments : IRequest<IEnumerable<TournamentInfoDto>> { }
}