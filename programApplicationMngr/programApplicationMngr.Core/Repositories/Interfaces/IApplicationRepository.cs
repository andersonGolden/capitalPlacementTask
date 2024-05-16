using programApplicationMngr.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programApplicationMngr.Core.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Applications>> GetAllAsync();
        Task<Applications> GetApplicationAsync(string applicationId);
        Task<Applications> CreateApplicationAsync(Applications application);
        Task<Applications> UpdateApplicationAsync(Applications application);
        Task<bool> DeleteApplicationAsync(string Id, string programId);
    }
}
