/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: TodoItemConfiguration.cs
/// File Description: The Entity Framework configuration for TodoItem model
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Models.EFC.Configurations.Category
{
    #region Using directives

    using WebApiBoilerplate.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion Using directives

    /// <summary>
    /// The configuration for <see cref="TodoItem"/> model
    /// </summary>
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TodoItems");
            builder.HasKey(item => item.Id);

            // Table properties
            builder.Property(item => item.Id)
                .IsRequired()
                .ValueGeneratedNever();
            
            builder.Property(item => item.TodoId)
                .IsRequired();

            builder.Property(item => item.Content)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(item => item.IsDone)
                .IsRequired();
        }
    }
}

