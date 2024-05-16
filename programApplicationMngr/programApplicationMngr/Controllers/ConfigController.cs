using Microsoft.AspNetCore.Mvc;
using programApplicationMngr.Core.Models;
using programApplicationMngr.Core.Repositories;
using programApplicationMngr.Core.Repositories.Interfaces;

namespace programApplicationMngr.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ConfigController(IQuestionTypeRepository _questionTypeRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionTypes>>> GetAllQuestionTypes()
        {
            var programs = await _questionTypeRepository.GetAllAsync();
            if (programs == null)
                return NoContent();

            return Ok(programs);
        }
    }
}
