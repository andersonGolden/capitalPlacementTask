using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using programApplicationMngr.Core.Models;
using programApplicationMngr.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programApplicationMngr.Core.Repositories
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _config;
        private readonly Container _questionTypeContainer;

        public QuestionTypeRepository(CosmosClient cosmosClient, IConfiguration config)
        {
            this._cosmosClient = cosmosClient;
            this._config = config;
            var dbName = _config["ComosDBSettings:DBName"];
            var _containerName = "QuestionTypes";
            _questionTypeContainer = _cosmosClient.GetContainer(dbName, _containerName);

        }

        public async Task<IEnumerable<QuestionTypes>> GetAllAsync()
        {
            try
            {
                //get all question types from db
                var query = _questionTypeContainer.GetItemLinqQueryable<QuestionTypes>().ToFeedIterator();
                var _questTypes = new List<QuestionTypes>();

                while (query.HasMoreResults)
                {
                    //read all results from query
                    var resp = await query.ReadNextAsync();
                    _questTypes.AddRange(resp);
                }

                return _questTypes;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
