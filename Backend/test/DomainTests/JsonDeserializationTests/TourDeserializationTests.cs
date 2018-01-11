using System.IO;
using Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shouldly;
using Xunit;

namespace DomainTests.JsonDeserializationTests
{
    public class TourDeserializationTests
    {
        public TourDeserializationTests()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
        }

        private readonly JsonSerializerSettings _settings;

        [Fact]
        public void Should_Deserialize_Tour_Correctly()
        {
            var tourJson = File.ReadAllText("Fixtures/Json/tour.json");

            var tour = JsonConvert.DeserializeObject<Tour>(tourJson, _settings);

            tour.Number.ShouldBe(100500);
        }
    }
}