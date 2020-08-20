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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepo;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepo = questionRepository;
        }

        /// <summary>
        /// Retreives all questions with choices and the category for each question. 
        /// </summary>
        /// <returns></returns>
        /// /// <response code="200">Returns all questions and related data.</response>
        /// <response code="204">If there is no data</response>
        // GET: api/<QuestionController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApplicationCore.Models.Question>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var questions = await _questionRepo.GetQuestionsAsync();

            if(questions == null)
                return NoContent();

            return Ok(questions);
        }

        /// <summary>
        /// Retrieves a single question with choices and the category.
        /// </summary>
        /// <param name="id">Thd id of the question to be returned.</param>
        /// <response code="200">Returns the question information.</response>
        /// <response code="404">If the question is not found.</response>
        /// <returns></returns>
        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationCore.Models.Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (await _questionRepo.GetQuestionAsync(id) is ApplicationCore.Models.Question question)
                return Ok(question);

            return NotFound();
        }

        /*
        // POST api/<QuestionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
