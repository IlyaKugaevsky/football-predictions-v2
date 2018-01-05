using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Predictions.Persistence;
using Predictions.PersistenceTests.LocalDbTests.DbInitializers;
using Predictions.Domain;
using Predictions.Utils.Json;

namespace Predictions.PersistenceTests.LocalDbTests.DbInitializers
{
    public class JsonDbInitializer<T>: IDbInitializer
        where T: Entity
    {
        private string _jsonData;
        private JsonSerializerSettings _settings; 

        public JsonDbInitializer(string jsonFilePath)
        {
            _jsonData = File.ReadAllText(jsonFilePath);
            _settings = new JsonSerializerSettings()
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