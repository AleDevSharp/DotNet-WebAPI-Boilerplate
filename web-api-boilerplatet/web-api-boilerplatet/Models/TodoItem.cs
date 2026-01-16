/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: TodoItem.cs
/// File Description: The Todo single item model class
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Models
{
    #region Using directives

    using System;

    #endregion Using directives

    /// <summary>
    /// The Todo single item model class
    /// </summary>
    public class TodoItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the todo id
        /// </summary>
        public required string TodoId { get; set; }

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
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        #endregion Properties

        #region Constructor 

        /// <summary>
        /// Initialize a new instance of <see cref="TodoItem"/> model
        /// </summary>
        public TodoItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        #endregion Constructor
    }
}
