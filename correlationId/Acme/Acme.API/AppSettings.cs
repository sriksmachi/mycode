using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.API
{
    /// <summary>
    /// 
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the redis connection string.
        /// </summary>
        /// <value>
        /// The redis connection string.
        /// </value>
        public string RedisConnectionString { get; set; }
        /// <summary>
        /// Gets or sets the name of the search service.
        /// </summary>
        /// <value>
        /// The name of the search service.
        /// </value>
        public string SearchServiceName { get; set; }
        /// <summary>
        /// Gets or sets the search API key.
        /// </summary>
        /// <value>
        /// The search API key.
        /// </value>
        public string SearchAPIKey { get; set; }
    }
}
