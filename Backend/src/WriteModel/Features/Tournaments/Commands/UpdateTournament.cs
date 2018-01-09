using System;
using System.Collections.Generic;
using MediatR;
using Predictions.WriteModel.Features.Tournaments.Dtos;

namespace Predictions.WriteModel.Features.Tournaments.Commands
{
    public class UpdateTournament: IRequest<bool> 
    { 
        public TournamentInfoWriteDto tournamentInfo { get; private set; }
    }
}