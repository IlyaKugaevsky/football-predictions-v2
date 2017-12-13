using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Predictions.Persistence;
using Predictions.Persistence.Entities;

namespace Predictions.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class TournamentsController : Controller
    {
        private PredictionsContext _context;

        public TournamentsController(PredictionsContext context)
        {
            _context = context;
        }

        // GET api/tournaments/latest/schedule

        [HttpGet("latest/schedule")]
        public async Task<Tournament> Get()
        {
            return await _context.Tournaments.Include(t => t.NewTours).LastAsync();
        }
    }
}