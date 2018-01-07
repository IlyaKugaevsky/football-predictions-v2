using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Predictions.Domain.Models;
using Shouldly;
using Xunit;

namespace Predictions.DomainTests.JsonDeserializationTests
{
    public class TourDeserializationTests
    {
        private JsonSerializerSettings _settings;
        public TourDeserializationTests()
        {
            _settings = new JsonSerializerSettings()
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
        }

        [Fact]
        public void Should_Deserialize_Tour_Correctly()
        {
            var tourJson = File.ReadAllText("Fixtures/Json/tour.json");

            var tour = JsonConvert.DeserializeObject<Tour>(tourJson, _settings);

            tour.Number.ShouldBe(100500);
        }
    }
}