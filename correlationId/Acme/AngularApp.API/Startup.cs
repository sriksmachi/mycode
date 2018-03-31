using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AngularApp.API.Repositories;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AngularApp.API
{
    public class Startup
    {
        /// <summary>
        /// Gets container reference
        /// </summary>
        public IContainer ApplicationContainer { get; private set; }

        /// <summary>
        /// Gets configuration reference
        /// </summary>
        public IConfigurationRoot Configuration { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            if (env.IsDevelopment())
            {
                // We load this as we need SSL port to be extracted from dev env
                builder.AddJsonFile(@"Properties/launchSettings.json", optional: true, reloadOnChange: true);
            }

            builder
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.Configure<DbConnectionFactoryOptions>(this.Configuration);
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            var builder = new ContainerBuilder();
            // register the autoFacModules found in loaded runtime assemblies
            builder.RegisterAssemblyModules(DependencyContext.Default.RuntimeLibraries.SelectMany(lib => lib.GetDefaultAssemblyNames(DependencyContext.Default).Select(Assembly.Load)).ToArray());
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.EnsureDatabaseIsSeeded(app.ApplicationServices.GetService<IOptions<AppSettings>>());
            }
            app.UseCors(builder =>
                            builder.WithOrigins("http://localhost:5000"));
            app.UseMvc();
        }
    }
}
