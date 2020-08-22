using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Trivia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Retrieves all User information.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns all user information</response>
        /// <response code="204">If there is no data</response>
        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApplicationCore.Models.User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetUsersAsync();

            if(users == null)
            {
                return NoContent();
            }
            return Ok(users);
        }

        /// <summary>
        /// Retrieves a single user.
        /// </summary>
        /// <param name="id">The id of the user to be returned.</param>
        /// <returns></returns>
        /// <response code="200">Returns the user information.</response>
        /// <response code="404">If the user is not found.</response>
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationCore.Models.User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if(await _userRepository.GetUserAsync(id) is ApplicationCore.Models.User user)
            {
                return Ok(user);
            }
            return NotFound();
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The user object that will be created.</param>
        /// <returns></returns>
        /// /// <response code="201">Returns the user information if creation was successful.</response>
        /// <response code="400">If invalid data was submitted.</response>
        /// <remarks>Id is not required input.</remarks>
        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(typeof(ApplicationCore.Models.User), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ApplicationCore.Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdItem = await _userRepository.AddUserAsync(user);

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new { id = createdItem.Id },
                value: createdItem);
        }

        /*
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
