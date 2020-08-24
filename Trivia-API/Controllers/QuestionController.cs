using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

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
        /// Retreives all questions with choices. 
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
        /// Retrieves all questions with the provided category.
        /// </summary>
        /// <param name="categoryId">The categoryId of the questions to be returned.</param>
        /// <returns></returns>
        /// <response code="200">Returns the questions.</response>
        /// <response code="404">If no questions for the category are found or the category does not exist.</response>
        // GET: api/<QuestionController>/getquestionsbycategory/1
        [HttpGet("getquestionsbycategory/{categoryId}")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationCore.Models.Question>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuestionsByCategory(int categoryId)
        {
            if (await _questionRepo.GetQuestionsByCategoryAsync(categoryId) is IEnumerable<ApplicationCore.Models.Question> questions)
            {
                if(questions.Count() > 0)
                    return Ok(questions);
            }

            return NotFound();
        }

        /// <summary>
        /// Retrieves a single question with choices using the provided id.
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

        /// <summary>
        /// Retrieves a random question.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the random question information.</response>
        /// <response code="204">If there are no questions in the DB.</response>
        // GET: api/question/getrandomquestion
        [HttpGet("getrandomquestion")]
        [ProducesResponseType(typeof(ApplicationCore.Models.Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetRandomQuestion()
        {
            var question = await _questionRepo.GetRandomQuestionAsync();

            if (question == null)
                return NoContent();

            return Ok(question);
        }

        /// <summary>
        /// Returns a random question within the given category.
        /// </summary>
        /// <param name="categoryId">The id of the category to pull a random question from.</param>
        /// <returns></returns>
        /// <response code="200">Returns the random question.</response>
        /// <response code="404">If no question for the category was found or the category does not exist.</response>
        // GET: api/question/getrandomquestionbycategory/1
        [HttpGet("getrandomquestionbycategory/{categoryId}")]
        [ProducesResponseType(typeof(ApplicationCore.Models.Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRandomQuestionByCategory(int categoryId)
        {
            var question = await _questionRepo.GetRandomQuestionByCategoryAsync(categoryId);

            if (question != null)
                return Ok(question);

            return NotFound();
        }

        /// <summary>
        /// Adds a new question with a minimum of 4 choices.
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /api/question
        ///     {
        ///         "categoryId": 4,
        ///         "questionString": "test question",
        ///         "value": 10,
        ///         "questionChoices": [
        ///             {
        ///                 "correct": true,
        ///                 "choiceString": "right choice"
        ///             },
        ///             {
        ///                 "correct": false,
        ///                 "choiceString": "wrong"
        ///             },
        ///             {
        ///                 "correct": false,
        ///                 "choiceString": "wrong"
        ///             },
        ///             {
        ///                 "correct": false,
        ///                 "choiceString": "wrong again"
        ///             }
        ///         ]
        ///     }
        /// Question must have at least 4 choices. questionId and choiceId inputs are not required and discarded if input.
        /// </remarks>
        /// <param name="question">The question object passed in the response body.</param>
        /// <returns></returns>
        /// <response code="201">Returns the question information if creation was successful.</response>
        /// <response code="400">If invalid data was submitted.</response>
        // POST api/<QuestionController>
        [HttpPost]
        [ProducesResponseType(typeof(ApplicationCore.Models.Question),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ApplicationCore.Models.Question question)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if(question.QuestionChoices.Count <4)
                return BadRequest("Question must have at least 4 choices.");
            if (!await _questionRepo.CategoryExistsAsync((int)question.CategoryId))
                return BadRequest($"Category with id {question.CategoryId} does not exist.");

            var createdItem = await _questionRepo.AddQuestionAsync(question);

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new { id = createdItem.QuestionId },
                value: createdItem);
        }

        /// <summary>
        /// Updates an existing question with its choices. Adds choices if they don't exist and removes choices if they exist in the database but are not included in response body.
        /// </summary>
        /// <param name="id">The id of the question to be updated or added.</param>
        /// <param name="question">The question object passed in the response body.</param>
        /// <returns></returns>
        /// <response code="204">If modification of question object was successful.</response>
        /// <response code="400">If invalid data was submitted.</response>
        /// <response code="404">If attempting to modify a question that does not exist.</response>
        /// <remarks>
        ///    Sample Request:
        ///    PUT /api/question/1
        ///    
        ///    {
        ///        "questionId": 1,
        ///        "categoryId": 1,
        ///        "questionString": "Which war movie won the Academy Award for Best Picture in 2009?",
        ///        "value": 10,
        ///        "questionChoices": [
        ///            {
        ///                "choiceId": 1,
        ///                "questionId": 1,
        ///                "correct": true,
        ///                "choiceString": "The Hurt Locker"
        ///            },
        ///            {
        ///                "choiceId": 2,
        ///                "questionId": 1,
        ///                "correct": false,
        ///                "choiceString": "Avatar"
        ///            },
        ///            {
        ///                "choiceId": 3,
        ///                "questionId": 1,
        ///                "correct": false,
        ///                "choiceString": "Zombieland"
        ///            },
        ///            {
        ///                "choiceId": 4,
        ///                "questionId": 1,
        ///                "correct": false,
        ///                "choiceString": "Inglourious Bastardos"
        ///            }
        ///        ]
        ///    }
        ///Question must have at least 4 choices.
        ///</remarks>
        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Put(int id, [FromBody] ApplicationCore.Models.Question question)
        {
            try
            {
                if (id != question.QuestionId)
                    return BadRequest("Question Ids do not match.");
                if (question.QuestionChoices.Count < 4)
                    return BadRequest("Question must have at least 4 choices.");

                var existing = await _questionRepo.GetQuestionAsync(id);
                if (existing is null)
                    return NotFound();

                var success = await _questionRepo.EditQuestionAsync(question);
                if (!success)
                    return BadRequest();

                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes the question and related choices of the given question id.
        /// </summary>
        /// <param name="id">The Id of the question to be deleted.</param>
        /// <returns></returns>
        /// <response code="204">If deletion of the question and choices was successful</response>
        /// <response code="404">If attempting to delete a question that does not exist.</response>
        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _questionRepo.RemoveQuestionAsync(id))
                return NoContent();

            return NotFound();
        }
    }
}
