/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: TodoItemDto.cs
/// File Description: The Todo single item dto model class
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.DTOs
{
    /// <summary>
    /// The Todo single item dto model class
    /// </summary>
    public class TodoItemDto
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the todo id
        /// </summary>
        public string? TodoId { get; set; }

        /// <summary>
        /// Gets or sets the content
        /// </summary>
        public required string Content { get; set; }

        /// <summary>
        /// Gets or sets the done flag
        /// </summary>
        public required bool IsDone { get; set; }

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
        /// Initialize a new instance of <see cref="TodoItemDto"/> model
        /// </summary>
        public TodoItemDto()
        {
        }

        #endregion Constructor
    }
}
