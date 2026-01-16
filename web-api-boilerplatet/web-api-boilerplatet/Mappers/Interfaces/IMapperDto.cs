/// --------------------------------------------------
/// Application: WebApiBoilerplate
/// Project: DotNet-WebAPI-Boilerplate
/// File name: IMapperDto.cs
/// File Description: The generic mapper interface
/// Author: Alessio Giacché (ale.giacc.dev@gmail.com)
/// License: MIT
/// --------------------------------------------------

namespace WebApiBoilerplate.Mappers.Interfaces
{
    /// <summary>
    /// The generic mapper interface for entity to DTO mapping
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    /// <typeparam name="TDto">The DTO type</typeparam>
    public interface IMapperDto<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        /// <summary>
        /// Maps an entity to DTO
        /// </summary>
        /// <param name="entity">The entity to map</param>
        /// <returns>The mapped DTO</returns>
        TDto MapToDto(TEntity entity);

        /// <summary>
        /// Maps a DTO to entity
        /// </summary>
        /// <param name="dto">The DTO to map</param>
        /// <param name="newEntity">Whether this is a new entity</param>
        /// <returns>The mapped entity</returns>
        TEntity MapToEntity(TDto dto, bool newEntity = false);
    }
}
