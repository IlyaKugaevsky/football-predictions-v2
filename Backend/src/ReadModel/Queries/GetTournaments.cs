using System;
using System.Collections.Generic;
using System.Linq;
using Predictions.Persistence;
using Predictions.Persistence.Entities;
using MediatR;

namespace Predictions.ReadModel.Queries
{
    public class GetTournaments : IRequest<IEnumerable<Tournament>> { }
}