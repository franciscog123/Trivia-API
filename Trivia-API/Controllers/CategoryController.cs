using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Trivia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }

        /// <summary>
        /// Retrieves all category information.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns all category information</response>
        /// <response code="204">If there is no data</response>
        // GET: api/<CategoryController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApplicationCore.Models.Category>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepo.GetCategoriesAsync();

            if (categories == null)
                return NoContent();

            return Ok(categories);
        }

        /// <summary>
        /// Retrieves a single category.
        /// </summary>
        /// <param name="id">The id of the category to be returned.</param>
        /// <returns></returns>
        /// <response code="200">Returns the category information.</response>
        /// <response code="404">If the category is not found.</response>
        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationCore.Models.Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (await _categoryRepo.GetCategoryAsync(id) is ApplicationCore.Models.Category category)
                return Ok(category);

            return NotFound();
        }

        /// <summary>
        /// Adds a new category.
        /// </summary>
        /// <param name="category">The category object that will be created.</param>
        /// <returns></returns>
        /// <response code="201">Returns the category information if creation was successful.</response>
        /// <response code="400">If invalid data was submitted.</response>
        /// <remarks>CategoryId is not required input.</remarks>
        // POST api/<CategoryController>
        [HttpPost]
        [ProducesResponseType(typeof(ApplicationCore.Models.Category), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdItem = await _categoryRepo.AddCategoryAsync(category);

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new { id = createdItem.CategoryId },
                value: createdItem);
        }
    }
}
