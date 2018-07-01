using Acme.API.Interfaces;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Data.SqlClient;

namespace Acme.API.Repositories
{
    /// <summary>
    /// A class representing SQL database connection factory
    /// </summary>
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        /// <summary>
        /// Connection string instance
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlConnectionFactory" /> class.
        /// </summary>
        /// <param name="optionsAccessor">Options object used to configure the SQL connection factory</param>
        public SqlConnectionFactory(IOptions<DbConnectionFactoryOptions> optionsAccessor)
        {
            this.connectionString = optionsAccessor.Value.ConnectionString;
        }

        /// <summary>
        /// Gets database connection produced by this factory
        /// </summary>
        public DbConnection Connection
        {
            get
            {
                // This extensibility point is needed to enable OAuth AuthN for SQL Azure as we need to control how the SQlConnection is created and then pass it to contexts
                return new SqlConnection(this.connectionString);
            }
        }
    }
}
