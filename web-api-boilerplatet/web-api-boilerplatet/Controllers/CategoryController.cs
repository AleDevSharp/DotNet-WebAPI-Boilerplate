/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: CategoryController.cs
/// File Description: The API controller for Category endpoints
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Controllers
{
    #region Using directives

    using WebApiBoilerplate.DTOs;
    using WebApiBoilerplate.Models;
    using WebApiBoilerplate.Services.Category.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    #endregion Using directives

    /// <summary>
    /// The API controller for <see cref="Category"/> endpoints
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        #region Attributes

        /// <summary>
        /// The <see cref="ICategoryService"/> category service
        /// </summary>
        private readonly ICategoryService categoryService;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="CategoryController"/> controller
        /// </summary>
        /// <param name="categoryService">The <see cref="ICategoryService"/> category service</param>
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        #endregion Constructor

        #region Endpoints

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>The categories list</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            var categories = await this.categoryService.GetAllAsync().ConfigureAwait(false);
            return Ok(categories);
        }

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">The category id</param>
        /// <returns>The category if found</returns>
        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await this.categoryService.GetByIdAsync(id).ConfigureAwait(false);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        /// <summary>
        /// Creates a category
        /// </summary>
        /// <param name="category">The category to create</param>
        /// <returns>The created category</returns>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateAsync([FromBody] CategoryDto category)
        {
            var created = await this.categoryService.AddAsync(category).ConfigureAwait(false);
            return CreatedAtRoute("GetCategoryById", new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates a category
        /// </summary>
        /// <param name="id">The category id</param>
        /// <param name="category">The category data</param>
        /// <returns>No content if updated</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] CategoryDto category)
        {
            if (id != category.Id)
            {
                return BadRequest("Category id mismatch.");
            }

            var updated = await this.categoryService.UpdateAsync(category).ConfigureAwait(false);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a category
        /// </summary>
        /// <param name="id">The category id</param>
        /// <returns>No content if deleted</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var deleted = await this.categoryService.DeleteAsync(id).ConfigureAwait(false);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        #endregion Endpoints
    }
}

