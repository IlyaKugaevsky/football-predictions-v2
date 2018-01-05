using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
// using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// using Predictions.Persistence;
// using Predictions.ReadModel.Features.Tournaments.Queries;
using Shouldly;
using Xunit;

namespace Predictions.ReadModelTests.Handlers
{
    public class TournamentHandlers
    {
        // private IMediator _mediator;
        // private PredictionsContext _context;

        //     private void SeedDatabase()
        //     {
        //         var trn1 = new Tournament()
        //         {
        //             TournamentId = 1
        //         };
        //         var trn2 = new Tournament()
        //         {
        //             TournamentId = 2
        //         };

        //         _context.Tournaments.Add(trn1);
        //         _context.Tournaments.Add(trn2);
        //         _context.SaveChanges();
        //     }
        //     public TournamentHandlers()
        //     {
        //         var services = new ServiceCollection();
        //         services.AddDbContext<PredictionsContext>(options => 
        //         {
        //             options.UseInMemoryDatabase(databaseName: "Predictions_test_in_memory");
        //         });
        //         services.AddMediatR();
        //         services.AddMediatR(Assembly.Load("ReadModel")); 

        //         var provider = services.BuildServiceProvider();
        //         _mediator = provider.GetService<IMediator>();
        //         _context = provider.GetService<PredictionsContext>();

        //         SeedDatabase();
        //     }

        //     [Fact]
        //     public async Task GetTournaments_Should_Fetch_All_Tournaments()
        //     {
        //         var getTournaments = new GetTournaments();
        //         var response = await _mediator.Send(getTournaments);
        //         response.Count().ShouldBe(2);
        //     }
    }
}