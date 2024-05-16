using Microsoft.AspNetCore.Mvc;
using programApplicationMngr.Core.Models;
using programApplicationMngr.Core.Repositories.Interfaces;
using System;
using System.Drawing.Printing;

namespace programApplicationMngr.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ProgramsController(IProgramRepository _programRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programs>>>GetAllPrograms()
        {
            var programs = await _programRepository.GetAllAsync();
            if (programs == null)
                return NoContent();

            return Ok(programs);
        }

        [HttpGet]
        public async Task<ActionResult<Programs>>GetProgram(string programId)
        {
            var program = await _programRepository.GetProgramAsync(programId);
            if (program == null)
                return NotFound();

            return Ok(program);
        }

        [HttpPost]
        public async Task<ActionResult<Programs>>CreateProgram(Programs program)
        {
            //check if program with the current programId exists
            var existingProgram = await _programRepository.GetProgramAsync(program.ProgramId);
            if (existingProgram != null)
                return BadRequest($"A program already exists with this program Id: {program.ProgramId}");

            var response = await _programRepository.CreateProgramAsync(program);
            if (response == null)
                return BadRequest("An error occured while creating program. Please try again.");

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<Programs>>UpdateProgram(Programs program)
        {
            //check if program with the current programId exists
            var programExists = await _programRepository.GetProgramAsync(program.ProgramId);
            if (programExists == null)
                return NotFound($"No program was found with this program Id: {program.ProgramId}");


            var response = await _programRepository.UpdateProgramAsync(program);
            if (response == null)
                return BadRequest($"An error occured while updating program. Please try again.");

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>>DeleteProgram(string Id, string programId)
        {
            //check if program with the current programId exists
            var programExists = await _programRepository.GetProgramAsync(programId);
            if (programExists == null)
                return NotFound($"No program was found with this program Id: {programId}");


            var response = await _programRepository.DeleteProgramAsync(Id,programId);
            if (!response)
                return BadRequest($"An error occured while deleting program. Please try again.");

            return Ok(true);
        }



    }
}
