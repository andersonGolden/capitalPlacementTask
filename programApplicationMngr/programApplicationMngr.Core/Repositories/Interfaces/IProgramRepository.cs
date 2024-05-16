using programApplicationMngr.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programApplicationMngr.Core.Repositories.Interfaces
{
    public interface IProgramRepository
    {
        Task<IEnumerable<Programs>> GetAllAsync();
        Task<Programs> GetProgramAsync(string progId);
        Task<Programs> CreateProgramAsync(Programs program);
        Task<Programs> UpdateProgramAsync(Programs program);
        Task<bool> DeleteProgramAsync(string Id, string programId);
    }
}
