/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: CategoryService.cs
/// File Description: The service implementation for Category model
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Services.Category
{
    #region Using directives

    using WebApiBoilerplate.DTOs;
    using WebApiBoilerplate.Models;
    using WebApiBoilerplate.Repositories.Category.Interfaces;
    using WebApiBoilerplate.Services.Category.Interfaces;
    using WebApiBoilerplate.Mappers;

    #endregion Using directives

    /// <summary>
    /// The service implementation for <see cref="Category"/> model
    /// </summary>
    public class CategoryService : ICategoryService
    {
        #region Attributes

        /// <summary>
        /// The <see cref="ICategoryRepository"/> category repository
        /// </summary>
        private readonly ICategoryRepository repository;

        /// <summary>
        /// The <see cref="CategoryMapper"/> category mapper
        /// </summary>
        private readonly CategoryMapper categoryMapper;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="CategoryService"/> service
        /// </summary>
        /// <param name="repository">the <see cref="ICategoryRepository"/> category repository</param>
        /// <param name="categoryMapper">the <see cref="CategoryMapper"/> category mapper</param>
        public CategoryService(ICategoryRepository repository, CategoryMapper categoryMapper)
        {
            this.repository = repository;
            this.categoryMapper = categoryMapper;
        }

        #endregion Constructor

        #region Public methods

        /// <inheritdoc/>
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await this.repository.GetAllAsync().ConfigureAwait(false);
            return categories.Select(categoryMapper.MapToDto);
        }

        /// <inheritdoc/>
        public async Task<CategoryDto?> GetByIdAsync(string id)
        {
            var category = await this.repository.GetByIdAsync(id).ConfigureAwait(false);
            return category == null ? null : categoryMapper.MapToDto(category);
        }

        /// <inheritdoc/>
        public async Task<CategoryDto> AddAsync(CategoryDto category)
        {
            // Build entity (with proper ids and relations) from dto
            var entity = categoryMapper.MapToEntity(category, newEntity: true);
            var created = await this.repository.AddAsync(entity).ConfigureAwait(false);

            return categoryMapper.MapToDto(created);
        }

        /// <inheritdoc/>
        public async Task<CategoryDto?> UpdateAsync(CategoryDto category)
        {
            var entity = categoryMapper.MapToEntity(category, newEntity: false);
            var updated = await this.repository.UpdateAsync(entity).ConfigureAwait(false);

            return updated == null ? null : categoryMapper.MapToDto(updated);
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(string id)
        {
            return await this.repository.DeleteAsync(id).ConfigureAwait(false);
        }

        #endregion Public methods
    }
}
