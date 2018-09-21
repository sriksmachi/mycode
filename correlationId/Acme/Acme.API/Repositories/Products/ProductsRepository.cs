using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AngularApp.API.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System.IO;
using Newtonsoft.Json;
using AngularApp.API.Interfaces;
using StackExchange.Redis;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Options;

/// <summary>
/// Products Repository
/// </summary>
namespace AngularApp.API.Repositories
{
    /// <summary>
    /// Products Repository Class.
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {
        /// <summary>
        /// The local storage object
        /// </summary>
        private readonly AcmeContext _storage;
        private readonly string redisConnectionString;
        private readonly string searchServiceName;
        private readonly string searchApikey;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsRepository"/> class.
        /// </summary>
        public ProductsRepository(IDbConnectionFactory dbConnectionFactory, IOptions<AppSettings> options)
        {
            _storage = new AcmeContext(dbConnectionFactory);
            redisConnectionString = options.Value.RedisConnectionString;
            searchServiceName = options.Value.SearchServiceName;
            searchApikey = options.Value.SearchAPIKey;
        }

        /// <summary>
        /// Gets the top5.
        /// </summary>
        /// <returns></returns>
        public IList<Product> GetTop5()
        {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            var database = connectionMultiplexer.GetDatabase();
            var products = JsonConvert.DeserializeObject<List<Product>>(database.StringGet("top5products"));
            return products;
        }

        /// <summary>
        /// Searches the specified search term.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <returns></returns>
        public IList<Product> Search(string searchTerm)
        {
            return _storage.Product.Where(p => p.ProductName.Contains(searchTerm)).ToList();
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Get Product by Id.</returns>
        public Product GetSingle(int id)
        {
            return _storage.Product.Find(id);
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>A Product</returns>
        /// <exception cref="System.Exception">Item could not be added</exception>
        public Product Add(Product item)
        {
            _storage.Product.Add(item);
            this._storage.SaveChanges();
            return item;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">Item could not be removed</exception>
        public void Delete(int id)
        {
            Product product = this._storage.Product.Find(id);
            _storage.Product.Remove(product);
            this._storage.SaveChanges();
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="item">The item.</param>
        /// <returns>The Product Item.</returns>
        public Product Update(int id, Product item)
        {
            _storage.Product.Update(item);
            this._storage.SaveChanges();
            return item;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List of Products.</returns>
        public IList<Product> GetAll()
        {
            var products = this._storage.Product.ToList();
            return products;
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>No. of Products</returns>
        public int Count()
        {
            return _storage.Product.Count();
        }
    }
}