using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeDataService
{
    public class CosmosDBDataService : ICosmosDBDataService
    {
        readonly CosmosClient _client;
        Database _db;
        private readonly string dbName = "OneStop";
        private readonly string collegeContainerId = "CollegeDataUSYearly";
        private readonly string matchContainerId = "MatchData";
        public CosmosDBDataService(string endpointUrl, string authKey)
        {
            _client = new CosmosClient(endpointUrl, authKey);
            _db = _client.GetDatabase(dbName);
        }
        public async Task<List<T>> SearchColleges<T>(string query)
        {
            return await Search<T>(collegeContainerId, query);
        }

        public async Task<List<T>> MatchColleges<T>(string query)
        {

            return await Search<T>(matchContainerId, query);
        }

        private async Task<List<T>> Search<T>(string containerId, string query)
        {
            var container = _db.GetContainer(containerId);
            var it = container.GetItemQueryIterator<T>(query);
            List<T> outcome = new List<T>();
            while (it.HasMoreResults)
            {
                var result = await it.ReadNextAsync();
                foreach (var item in result)
                    outcome.Add(item);
            }

            return outcome;
        }
    }
}
