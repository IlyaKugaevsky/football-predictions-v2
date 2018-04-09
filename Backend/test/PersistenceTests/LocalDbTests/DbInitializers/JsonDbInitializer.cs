using System.Collections.Generic;
using System.IO;
using Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Utils.Json;

namespace PersistenceTests.LocalDbTests.DbInitializers
{
    public class JsonDbInitializer<T> : IDbInitializer
        where T : Domain.Entity
    {
        private readonly string _jsonData;
        private readonly JsonSerializerSettings _settings;

        public JsonDbInitializer(string jsonFilePath)
        {
            _jsonData = File.ReadAllText(jsonFilePath);
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new AllPropsAndFieldsContractResolver()
            };
        }

        public void SeedDatabase(DbContext context)
        {
            var entities = JsonConvert.DeserializeObject<IEnumerable<T>>(_jsonData, _settings);

            context.Set<T>().AddRange(entities);
            context.SaveChanges();
        }
    }
}