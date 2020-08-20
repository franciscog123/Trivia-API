using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trivia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameModeController : ControllerBase
    {
        private readonly IGameModeRepository _modeRepo;

        public GameModeController(IGameModeRepository gameModeRepository)
        {
            _modeRepo = gameModeRepository;
        }

        /// <summary>
        /// Retrieves all game modes.
        /// </summary>
        /// <returns></returns>
        /// /// <response code="200">Returns all game mode information</response>
        /// <response code="204">If there is no data</response>
        // GET: api/<GameModeController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApplicationCore.Models.GameMode>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var modes = await _modeRepo.GetGameModesAsync();

            if (modes == null)
                return NoContent();

            return Ok(modes);
        }

        /// <summary>
        /// Retrieves a single game mode.
        /// </summary>
        /// <param name="id">The id of the game mode to be returned.</param>
        /// <returns></returns>
        /// /// <response code="200">Returns the game mode information.</response>
        /// <response code="404">If the game mode is not found.</response>
        // GET api/<GameModeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationCore.Models.GameMode), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (await _modeRepo.GetGameModeAsync(id) is ApplicationCore.Models.GameMode mode)
                return Ok(mode);

            return NotFound();
        }

        /*
        // POST api/<GameModeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameModeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameModeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
