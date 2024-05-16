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
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _config;
        private readonly Container _applicationContainer;

        public ApplicationRepository(CosmosClient cosmosClient, IConfiguration config)
        {
            this._cosmosClient = cosmosClient;
            this._config = config;
            var dbName = _config["ComosDBSettings:DBName"];
            var _containerName = "Applications";
            _applicationContainer = _cosmosClient.GetContainer(dbName, _containerName);

        }

        public async Task<IEnumerable<Applications>> GetAllAsync()
        {
            try
            {
                //get all applications from db
                var query = _applicationContainer.GetItemLinqQueryable<Applications>().ToFeedIterator();
                var _applicationsList = new List<Applications>();

                while (query.HasMoreResults)
                {
                    //read all results from query
                    var resp = await query.ReadNextAsync();
                    _applicationsList.AddRange(resp);
                }

                return _applicationsList;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<Applications> GetApplicationAsync(string applicationId)
        {
            try
            {
                //get application from db
                var query = _applicationContainer.GetItemLinqQueryable<Applications>()
                    .Where(p => p.ApplicantionId == applicationId)
                    .ToFeedIterator();

                var response = await query.ReadNextAsync();
                return response.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<Applications> CreateApplicationAsync(Applications application)
        {
            try
            {
                //create new application & return successfully created object
                var response = await _applicationContainer.CreateItemAsync(application);
                return response.Resource;
            }
            catch (Exception ex)
            {
                //catch exception and return empty object
                return default;
            }
        }

        public async Task<Applications> UpdateApplicationAsync(Applications application)
        {
            try
            {
                //update existing application
                var response = await _applicationContainer.ReplaceItemAsync(application, application.id);
                return response.Resource;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<bool> DeleteApplicationAsync(string Id, string programId)
        {
            try
            {
                //delete existing application by id & partition key
                var response = await _applicationContainer.DeleteItemAsync<Applications>(Id, new PartitionKey(programId));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
