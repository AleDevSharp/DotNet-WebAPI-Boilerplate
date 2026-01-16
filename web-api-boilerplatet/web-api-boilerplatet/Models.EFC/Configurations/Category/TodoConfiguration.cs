/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: TodoConfiguration.cs
/// File Description: The Entity Framework configuration for Todo model
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
    /// The configuration for <see cref="Todo"/> model
    /// </summary>
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");
            builder.HasKey(todo => todo.Id);
            
            // Table properties
            builder.Property(todo => todo.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(todo => todo.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(todo => todo.IsComplete)
                .IsRequired();

            builder.Property(todo => todo.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(todo => todo.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(todo => todo.CategoryId)
                .IsRequired();

            // Relationships
            builder.HasOne(todo => todo.Category)
                .WithMany(category => category.Todos)
                .HasForeignKey(todo => todo.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(todo => todo.Items)
                .WithOne()
                .HasForeignKey(item => item.TodoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

