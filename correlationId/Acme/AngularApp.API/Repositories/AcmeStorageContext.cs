using AngularApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;
using AngularApp.API.Interfaces;
using System.IO;
using Newtonsoft.Json;

namespace AngularApp.API.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class AcmeStorageContext : DbContext
    {

        /// <summary>
        /// A database connection
        /// </summary>
        private DbConnection connection;

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public virtual DbSet<Product> Product { get; set; }

        /// <summary>
        /// Ensures the seed data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal int EnsureSeedData()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            var filePath = directory + @"\api\products\products.json";

            // read file into a string and deserialize JSON to a type
            if (!File.Exists(filePath))
                throw new ArgumentNullException("Products data does not exist");

            IList<Product> products = JsonConvert
                .DeserializeObject<IList<Product>>(File.ReadAllText(filePath)).ToList();

            if (this.Product.Count() == 0)
            {
                this.Product.UpdateRange(products);
                this.SaveChanges();
            }

            return 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AcmeStorageContext"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public AcmeStorageContext(IDbConnectionFactory dbConnection)
        {
            this.connection = dbConnection.Connection;
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connection);
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ImageUrl).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductCode).HasMaxLength(10);

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });
        }
    }
}
