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
    public class ProgramRepository : IProgramRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _config;
        private readonly Container _progContainer;

        public ProgramRepository(CosmosClient cosmosClient, IConfiguration config)
        {
            this._cosmosClient = cosmosClient;
            this._config = config;            
            var dbName = _config["ComosDBSettings:DBName"];
            var _containerName = "Programs";
            _progContainer = _cosmosClient.GetContainer(dbName, _containerName);
        }

        public async Task<IEnumerable<Programs>> GetAllAsync()
        {
            try
            {
                //get all programs from db
                var query = _progContainer.GetItemLinqQueryable<Programs>().ToFeedIterator();
                var _programs = new List<Programs>();

                while (query.HasMoreResults)
                {
                    //read all results from query
                    var resp = await query.ReadNextAsync();
                    _programs.AddRange(resp);
                }

                return _programs;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<Programs> GetProgramAsync(string progId)
        {
            try
            {
                //get program from db
                var query = _progContainer.GetItemLinqQueryable<Programs>()
                    .Where(p => p.ProgramId == progId)
                    .ToFeedIterator();

                var response = await query.ReadNextAsync();
                return response.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<Programs> CreateProgramAsync(Programs program)
        {
            try
            {
                //create new task & return successfully created object
                var response = await _progContainer.CreateItemAsync(program);
                return response.Resource;
            }
            catch (Exception ex)
            {
                //catch exception and return empty object
                return default;
            }
        }

        public async Task<Programs> UpdateProgramAsync(Programs program)
        {
            try
            {
                //update existing
                var response = await _progContainer.ReplaceItemAsync(program, program.id);
                return response.Resource;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<bool> DeleteProgramAsync(string Id, string programId)
        {
            try
            {
                var response = await _progContainer.DeleteItemAsync<Programs>(Id, new PartitionKey(programId));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
