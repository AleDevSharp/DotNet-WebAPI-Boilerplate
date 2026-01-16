/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: ApplicationDbContext.cs
/// File Description: The Entity Framework database context
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Models.EFC
{
    #region Using directives

    using WebApiBoilerplate.Models;
    using Microsoft.EntityFrameworkCore;

    #endregion Using directives

    /// <summary>
    /// The Entity Framework Core database context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="ApplicationDbContext"/>
        /// </summary>
        /// <param name="options">The DbContext options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #endregion Constructor

        #region DbSets

        /// <summary>
        /// Gets or sets the categories set
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the todos set
        /// </summary>
        public DbSet<Todo> Todos { get; set; }

        /// <summary>
        /// Gets or sets the todo items set
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }

        #endregion DbSets

        #region Methods

        /// <summary>
        /// Configure the model
        /// </summary>
        /// <param name="modelBuilder">The model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            modelBuilder.ApplyConfiguration(new Configurations.Category.CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.Category.TodoConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.Category.TodoItemConfiguration());
        }

        #endregion Methods
    }
}

