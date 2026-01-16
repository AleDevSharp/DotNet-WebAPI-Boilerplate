/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: CategoryMapper.cs
/// File Description: The Category entity to DTO mapper
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Mappers
{
    #region Using directives

    using WebApiBoilerplate.DTOs;
    using WebApiBoilerplate.Models;
    using WebApiBoilerplate.Mappers.Interfaces;

    #endregion Using directives

    /// <summary>
    /// The Category entity to DTO mapper implementation
    /// </summary>
    public class CategoryMapper : IMapperDto<Category, CategoryDto>
    {
        #region Constructor

        /// <summary>
        /// Initialize a new instance of <see cref="CategoryMapper"/> mapper
        /// </summary>
        public CategoryMapper()
        {
        }

        #endregion Constructor

        #region Public methods

        /// <summary>
        /// Maps a <see cref="Category"/> entity to <see cref="CategoryDto"/>
        /// </summary>
        /// <param name="entity">The category entity</param>
        /// <returns>The category DTO</returns>
        public CategoryDto MapToDto(Category entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Todos = entity.Todos?
                    .Select(MapTodoToDto)
                    .ToList()
            };
        }

        /// <summary>
        /// Maps a <see cref="CategoryDto"/> to <see cref="Category"/> entity
        /// </summary>
        /// <param name="dto">The category DTO</param>
        /// <param name="newEntity">Whether this is a new entity</param>
        /// <returns>The category entity</returns>
        public Category MapToEntity(CategoryDto dto, bool newEntity = false)
        {
            // If Id is null/empty we let the Category constructor create a new guid
            var category = new Category
            {
                Name = dto.Name
            };

            category.UpdatedAt = DateTime.UtcNow;
            if (newEntity)
            {
                category.CreatedAt = DateTime.UtcNow;
            }

            // If dto has an id (update scenario), keep it
            if (!string.IsNullOrWhiteSpace(dto.Id))
            {
                category.Id = dto.Id;
            }

            // Handle nested todos if provided in dto
            if (dto.Todos != null && dto.Todos.Count > 0)
            {
                category.Todos.Clear();

                foreach (var todoDto in dto.Todos)
                {
                    var todo = MapTodoToEntity(todoDto, category.Id, newEntity);
                    category.Todos.Add(todo);
                }
            }

            return category;
        }

        #endregion Public methods

        #region Private methods

        /// <summary>
        /// Maps a <see cref="Todo"/> entity to <see cref="TodoDto"/>
        /// </summary>
        /// <param name="todo">The todo entity</param>
        /// <returns>The todo DTO</returns>
        private static TodoDto MapTodoToDto(Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsComplete = todo.IsComplete,
                CreatedAt = todo.CreatedAt,
                UpdatedAt = todo.UpdatedAt,
                CategoryId = todo.CategoryId,
                // Avoid circular reference: we do not populate Category here
                Category = null,
                Items = todo.Items?
                    .Select(MapTodoItemToDto)
                    .ToList()
            };
        }

        /// <summary>
        /// Maps a <see cref="TodoDto"/> to <see cref="Todo"/> entity
        /// </summary>
        /// <param name="dto">The todo DTO</param>
        /// <param name="categoryId">The parent category id</param>
        /// <param name="newEntity">Indicates if this is a new entity</param>
        /// <returns>The todo entity</returns>
        private static Todo MapTodoToEntity(TodoDto dto, string categoryId, bool newEntity)
        {
            var todo = new Todo
            {
                Title = dto.Title,
                IsComplete = dto.IsComplete,
                CategoryId = categoryId
            };

            if (!string.IsNullOrWhiteSpace(dto.Id))
            {
                todo.Id = dto.Id;
            }

            todo.UpdatedAt = DateTime.UtcNow;
            if (newEntity)
            {
                todo.CreatedAt = DateTime.UtcNow;
            }

            if (dto.Items != null && dto.Items.Count > 0)
            {
                todo.Items.Clear();

                foreach (var itemDto in dto.Items)
                {
                    var item = MapTodoItemToEntity(itemDto, todo.Id, newEntity);
                    todo.Items.Add(item);
                }
            }

            return todo;
        }

        /// <summary>
        /// Maps a <see cref="TodoItem"/> entity to <see cref="TodoItemDto"/>
        /// </summary>
        /// <param name="item">The entity</param>
        /// <returns>The todo item DTO</returns>
        private static TodoItemDto MapTodoItemToDto(TodoItem item)
        {
            return new TodoItemDto
            {
                Id = item.Id,
                TodoId = item.TodoId,
                Content = item.Content,
                IsDone = item.IsDone,
                CreatedAt = item.CreatedAt,
                UpdatedAt = item.UpdatedAt
            };
        }

        /// <summary>
        /// Maps a <see cref="TodoItemDto"/> to <see cref="TodoItem"/> entity
        /// </summary>
        /// <param name="dto">The todo item DTO</param>
        /// <param name="todoId">The parent todo id</param>
        /// <param name="newEntity">Indicates if this is a new entity</param>
        /// <returns>The todo item entity</returns>
        private static TodoItem MapTodoItemToEntity(TodoItemDto dto, string todoId, bool newEntity)
        {
            var item = new TodoItem
            {
                TodoId = todoId,
                Content = dto.Content,
                IsDone = dto.IsDone
            };

            if (!string.IsNullOrWhiteSpace(dto.Id))
            {
                item.Id = dto.Id;
            }

            item.UpdatedAt = DateTime.UtcNow;
            if (newEntity)
            {
                item.CreatedAt = DateTime.UtcNow;
            }

            return item;
        }

        #endregion Private methods
    }
}
