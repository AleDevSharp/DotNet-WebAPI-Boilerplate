/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: Todo.cs
/// File Description: The Todo model class
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Models
{    
    /// <summary>
    /// The Todo model class
    /// </summary>
    public class Todo
    {
        #region Properties

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the complete flag
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Gets or sets the date created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        #endregion Properties

        #region Nav properties

        /// <summary>
        /// Gets or sets the category id
        /// </summary>
        public string CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category
        /// </summary>
        public Category Category { get; set; }
        
        /// <summary>
        /// Gets or sets the item
        /// </summary>
        public List<TodoItem> Items { get; set; } = new();

        #endregion Nav properties

        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="Todo"/> model class
        /// </summary>
        public Todo()
        {
            Id = Guid.NewGuid().ToString();
        }

        #endregion Constructor
    }
}
