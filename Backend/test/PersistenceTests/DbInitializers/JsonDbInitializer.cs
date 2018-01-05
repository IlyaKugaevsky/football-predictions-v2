using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Predictions.Persistence;
using Predictions.PersistenceTests.DbInitializers;
using Predictions.Domain;
using Predictions.Utils.Json;

namespace Predictions.PersistenceTests.DbInitializers
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
        
        public void SeedDatabase(PredictionsContext context)
        {
            var entities = JsonConvert.DeserializeObject<IEnumerable<T>>(_jsonData, _settings);

            context.Set<T>().AddRange(entities);
            context.SaveChanges();
        }
    }
}