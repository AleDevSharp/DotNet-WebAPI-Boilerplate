/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: ICategoryRepository.cs
/// File Description: The repository interface for Category model
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Repositories.Category.Interfaces
{
    #region Using directives

    using WebApiBoilerplate.Models;

    #endregion Using directives

    /// <summary>
    /// The repository interface for <see cref="Category"/> model
    /// </summary>
    public interface ICategoryRepository
    {
        #region Methods

        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>The list of categories</returns>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">The category id</param>
        /// <returns>The category if found</returns>
        Task<Category?> GetByIdAsync(string id);

        /// <summary>
        /// Adds a new category
        /// </summary>
        /// <param name="category">The category to add</param>
        /// <returns>The created category</returns>
        Task<Category> AddAsync(Category category);

        /// <summary>
        /// Updates an existing category
        /// </summary>
        /// <param name="category">The category to update</param>
        /// <returns>The updated category</returns>
        Task<Category?> UpdateAsync(Category category);

        /// <summary>
        /// Deletes a category by id
        /// </summary>
        /// <param name="id">The category id</param>
        /// <returns>True if deleted</returns>
        Task<bool> DeleteAsync(string id);

        #endregion Methods
    }
}

