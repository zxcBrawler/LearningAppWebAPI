using LearningAppWebAPI.Data;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The abstract base repository class
    /// </summary>
    public abstract class AbstractBaseRepository<TE, TKey>(AppDbContext context)
    {

        /// <summary>
        /// The context
        /// </summary>
        protected readonly AppDbContext Context = context;

        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a list of te</returns>
        public abstract Task<List<TE>> GetAllAsync();
        /// <summary>
        /// Gets Entity by id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the te</returns>
        public abstract Task<TE?> GetByIdAsync(TKey id);
        /// <summary>
        /// Creates the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <returns>A task containing the te</returns>
        public abstract Task<TE> CreateAsync(TE entity);
        /// <summary>
        /// Updates Entity by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="entity">The entity</param>
        /// <returns>A task containing the bool</returns>
        public abstract Task<bool> UpdateAsync(TKey id, TE entity);
        /// <summary>
        /// Deletes Entity by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>A task containing the bool</returns>
        public abstract Task<bool> DeleteAsync(TKey id);
    }
}
