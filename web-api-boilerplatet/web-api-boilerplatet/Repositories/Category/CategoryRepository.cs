/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: CategoryRepository.cs
/// File Description: The repository implementation for Category model
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Repositories.Category
{
    #region Using directives

    using WebApiBoilerplate.Models;
    using WebApiBoilerplate.Models.EFC;
    using WebApiBoilerplate.Repositories.Category.Interfaces;
    using Microsoft.EntityFrameworkCore;

    #endregion Using directives

    /// <summary>
    /// The repository implementation for <see cref="Category"/> model
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        #region Attributes

        /// <summary>
        /// The <see cref="ApplicationDbContext"/> context
        /// </summary>
        private readonly ApplicationDbContext context;

        #endregion Attributes

        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="CategoryRepository"/> repository
        /// </summary>
        /// <param name="context">the <see cref="ApplicationDbContext"/> context</param>
        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion Constructor

        #region Public methods

        /// <inheritdoc/>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await this.context.Categories
                .AsNoTracking()
                .Include(category => category.Todos)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<Category?> GetByIdAsync(string id)
        {
            return await this.context.Categories
                .AsNoTracking()
                .Include(category => category.Todos)
                .FirstOrDefaultAsync(category => category.Id == id)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<Category> AddAsync(Category category)
        {
            await this.context.Categories.AddAsync(category).ConfigureAwait(false);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
            return category;
        }

        /// <inheritdoc/>
        public async Task<Category?> UpdateAsync(Category category)
        {
            var exists = await this.context.Categories
                .AnyAsync(current => current.Id == category.Id)
                .ConfigureAwait(false);

            if (!exists)
            {
                return null;
            }

            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
            return category;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(string id)
        {
            var category = await this.context.Categories
                .FirstOrDefaultAsync(current => current.Id == id)
                .ConfigureAwait(false);

            if (category == null)
            {
                return false;
            }

            this.context.Categories.Remove(category);
            await this.context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        #endregion Public methods
    }
}

