using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.API.Interfaces;
using Acme.API.Repositories;
using Autofac;

namespace Acme.API
{
    public class AutofacRepositoriesModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductsRepository>().As<IProductsRepository>().InstancePerDependency();
            builder.RegisterType<SqlConnectionFactory>().As<IDbConnectionFactory>().SingleInstance();
            base.Load(builder);
        }
    }
}
