/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: Category.cs
/// File Description: The Category model class
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Models
{
    /// <summary>
    /// The Category model class
    /// </summary>
    public class Category
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the todos item
        /// </summary>
        public List<Todo> Todos { get; set; }

        /// <summary>
        /// Gets or sets the date created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="Category"/> model
        /// </summary>
        public Category()
        {
            Id = Guid.NewGuid().ToString();
            this.Todos = new List<Todo>();
        }

        #endregion Constructor
    }
}
