/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: TodoDto.cs
/// File Description: The Todo dto model class
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.DTOs
{
    #region Using directives

    using WebApiBoilerplate.Models;

    #endregion Using directives

    /// <summary>
    /// The Todo dto model class
    /// </summary>
    public class TodoDto
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the complete flag
        /// </summary>
        public required bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets the date created
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        #endregion Properties

        #region Nav properties

        /// <summary>
        /// Gets or sets the category id
        /// </summary>
        public string? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category
        /// </summary>
        public CategoryDto? Category { get; set; }

        /// <summary>
        /// Gets or sets the item
        /// </summary>
        public List<TodoItemDto>? Items { get; set; } = new();

        #endregion Nav properties

        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="TodoDto"/> model class
        /// </summary>
        public TodoDto()
        {
        }

        #endregion Constructor
    }
}
