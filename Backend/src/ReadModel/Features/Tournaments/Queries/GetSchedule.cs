using System;
using System.Collections.Generic;
using MediatR;
using Predictions.ReadModel.Features.Tournaments.Dtos;

namespace Predictions.ReadModel.Features.Tournaments.Queries
{
    public class GetSchedule : IRequest<TournamentScheduleDto> { }

}