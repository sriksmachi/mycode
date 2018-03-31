using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AngularApp.API.Models;

/// <summary>
/// Things Repository
/// </summary>
namespace AngularApp.API.Repositories
{
    /// <summary>
    /// Things Repository Class
    /// </summary>
    public class ThingsRepository : IThingsRepository
    {
        /// <summary>
        /// The local storage object
        /// </summary>
        private readonly ConcurrentDictionary<int, Thing> _storage = new ConcurrentDictionary<int, Thing>();

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Thing Item.</returns>
        public Thing GetSingle(int id)
        {
            Thing thing;
            return _storage.TryGetValue(id, out thing) ? thing : null;
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Thing Item</returns>
        /// <exception cref="System.Exception">Item could not be added</exception>
        public Thing Add(Thing item)
        {
            item.Id = !GetAll().Any() ? 1 : GetAll().Max(x => x.Id) + 1;

            if (_storage.TryAdd(item.Id, item))
            {
                return item;
            }

            throw new Exception("Item could not be added");
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">Item could not be removed</exception>
        public void Delete(int id)
        {
            Thing thing;
            if (!_storage.TryRemove(id, out thing))
            {
                throw new Exception("Item could not be removed");
            }
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>Thing Item.</returns>
        public Thing Update(int id, Thing item)
        {
            _storage.TryUpdate(id, item, GetSingle(id));
            return item;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of things.</returns>
        public ICollection<Thing> GetAll()
        {
            return _storage.Values;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>no. of items.</returns>
        public int Count()
        {
            return _storage.Count;
        }
    }
}