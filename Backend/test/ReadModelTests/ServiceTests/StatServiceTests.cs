using Domain.Models;
using Domain.Services;
using Newtonsoft.Json;
using ReadModel.Features.Stats;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utils.Json;
using Xunit;

namespace ReadModelTests.ServiceTests
{
    public class StatServiceTests
    {
        private readonly StatService _statService;

        public StatServiceTests()
        {
            _statService = new StatService();
        }

        //[Fact]
        //public void Should_Denormalize_Dictionary_Correctly()
        //{

        //}

    }
}
