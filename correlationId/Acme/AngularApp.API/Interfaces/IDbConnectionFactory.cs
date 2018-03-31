using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.API.Interfaces
{
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// Gets database connection created by this factory
        /// </summary>
        DbConnection Connection { get; }
    }
}
