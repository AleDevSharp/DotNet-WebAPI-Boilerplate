/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: ICategoryService.cs
/// File Description: The service interface for Category model
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Services.Category.Interfaces
{
    #region Using directives

    using WebApiBoilerplate.Models;
    using WebApiBoilerplate.DTOs;

    #endregion Using directives

    /// <summary>
    /// The service interface for <see cref="Category"/> model
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>The list of categories</returns>
        Task<IEnumerable<CategoryDto>> GetAllAsync();

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">The category id</param>
        /// <returns>The category if found</returns>
        Task<CategoryDto?> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new category
        /// </summary>
        /// <param name="category">The category to add</param>
        /// <returns>The created category</returns>
        Task<CategoryDto> AddAsync(CategoryDto category);

        /// <summary>
        /// Updates an existing category
        /// </summary>
        /// <param name="category">The category to update</param>
        /// <returns>The updated category</returns>
        Task<CategoryDto?> UpdateAsync(CategoryDto category);

        /// <summary>
        /// Deletes a category by id
        /// </summary>
        /// <param name="id">The category id</param>
        /// <returns>True if deleted</returns>
        Task<bool> DeleteAsync(string id);
    }
}

