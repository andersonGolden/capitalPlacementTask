using Microsoft.AspNetCore.Mvc;
using programApplicationMngr.Core.Models;
using programApplicationMngr.Core.Repositories;
using programApplicationMngr.Core.Repositories.Interfaces;

namespace programApplicationMngr.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ApplicationsController(IApplicationRepository _applicationRepository, IProgramRepository _programRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applications>>> GetApplications()
        {
            var programs = await _applicationRepository.GetAllAsync();
            if (programs == null)
                return NoContent();

            return Ok(programs);
        }

        [HttpGet]
        public async Task<ActionResult<Applications>> GetApplication(string applicationId)
        {
            var program = await _applicationRepository.GetApplicationAsync(applicationId);
            if (program == null)
                return NotFound();

            return Ok(program);
        }

        [HttpPost]
        public async Task<ActionResult<Applications>> CreateApplication(Applications application)
        {
            //check if the program being applied for exists
            var programExists = await _programRepository.GetProgramAsync(application.ProgramId);
            if (programExists == null)
                return BadRequest($"Invalid program Id: {application.ProgramId}.");

            //check if the application with current id already exists
            var applicationExists = await _applicationRepository.GetApplicationAsync(application.ApplicantionId);
            if (applicationExists != null)
                return BadRequest($"Application already exists with Id: {application.ApplicantionId}.");

            var response = await _applicationRepository.CreateApplicationAsync(application);
            if (response == null)
                return BadRequest("An error occured while creating application. Please try again.");

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Applications>> UpdateApplication(Applications application)
        {
            //check if the program being applied for exists
            var programExists = await _programRepository.GetProgramAsync(application.ProgramId);
            if (programExists == null)
                return NotFound($"Invalid program Id:: {application.ProgramId}");


            var response = await _applicationRepository.UpdateApplicationAsync(application);
            if (response == null)
                return BadRequest($"An error occured while updating application. Please try again.");

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteApplication(string Id, string programId)
        {
            var response = await _applicationRepository.DeleteApplicationAsync(Id, programId);
            if (!response)
                return BadRequest($"An error occured while deleting application. Please try again.");

            return Ok(true);
        }
    }
}
