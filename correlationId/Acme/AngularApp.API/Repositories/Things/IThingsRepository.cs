using System.Collections.Generic;
using AngularApp.API.Models;

/// <summary>
/// Things Repository.
/// </summary>
namespace AngularApp.API.Repositories
{
    /// <summary>
    /// Things Repository Interface.
    /// </summary>
    public interface IThingsRepository
    {
        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Thing Item</returns>
        Thing GetSingle(int id);

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Thing Item</returns>
        Thing Add(Thing item);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>Thing Item</returns>
        Thing Update(int id, Thing item);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of Thing Items.</returns>
        ICollection<Thing> GetAll();

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>no. of thing items.</returns>
        int Count();
    }
}
