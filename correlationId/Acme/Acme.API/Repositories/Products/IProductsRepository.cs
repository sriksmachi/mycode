using System.Collections.Generic;
using Acme.API.Models;

/// <summary>
/// Products Repository.
/// </summary>
namespace Acme.API.Repositories
{
    /// <summary>
    /// Products Repository Interface
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Product Item</returns>
        Product GetSingle(int id);

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Product Item</returns>
        Product Add(Product item);

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
        /// <returns>Product Item</returns>
        Product Update(int id, Product item);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of Product Items</returns>
        IList<Product> GetAll();

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>no. of products</returns>
        int Count();

        /// <summary>
        /// Searches the specified search term.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <returns></returns>
        IList<Product> Search(string searchTerm);

        /// <summary>
        /// Gets the top5.
        /// </summary>
        /// <returns></returns>
        IList<Product> GetTop5();
    }
}
