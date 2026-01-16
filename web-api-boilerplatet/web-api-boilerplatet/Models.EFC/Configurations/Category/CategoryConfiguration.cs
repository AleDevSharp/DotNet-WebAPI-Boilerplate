/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: CategoryConfiguration.cs
/// File Description: The Entity Framework configuration for Category model
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
    /// The configuration for <see cref="Category"/> model
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(category => category.Id);

            // Table properties
            builder.Property(category => category.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Relationships
            builder.HasMany(category => category.Todos)
                .WithOne(todo => todo.Category)
                .HasForeignKey(todo => todo.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

