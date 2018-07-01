using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.API.Repositories
{
    public class DbConnectionFactoryOptions
    {
        /// <summary>
        /// Gets or sets connection string for the database
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
