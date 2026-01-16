/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: CategoryDto.cs
/// File Description: The Category dto model class
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.DTOs
{
    /// <summary>
    /// The Category dto model class
    /// </summary>
    public class CategoryDto
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the todos item
        /// </summary>
        public List<TodoDto>? Todos { get; set; }

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
        /// Initialize a new instance of <see cref="CategoryDto"/> model
        /// </summary>
        public CategoryDto()
        {
        }

        #endregion Constructor
    }
}
