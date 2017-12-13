using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Predictions.Persistence;
using Predictions.Persistence.Entities;
using MediatR;

namespace Predictions.WebApi.ReadModel.Queries
{
    public class GetTournaments : IRequest<string> { }
}