using programApplicationMngr.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programApplicationMngr.Core.Repositories.Interfaces
{
    public interface IQuestionTypeRepository
    {
        Task<IEnumerable<QuestionTypes>> GetAllAsync();
    }
}
