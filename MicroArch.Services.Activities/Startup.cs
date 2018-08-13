using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MicroArch.Common.Commands;
using MicroArch.Common.Events;
using MicroArch.Common.Mongo;
using MicroArch.Common.RabbitMQ;
using MicroArch.Services.Activities.Domain.Repositories;
using MicroArch.Services.Activities.Handlers;
using MicroArch.Services.Activities.Repositories;
using MicroArch.Services.Activities.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MicroArch.Services.Activities
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRabbitMq(Configuration);
            services.AddMongoDb(Configuration);
            services.AddLogging();
            services.AddSingleton<ICommandHandler<CreateActivity>, CreateActivityHandler>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDatabaseSeeder, NewMongoSeeder>();
            

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddDebug();
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

           // app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope.ServiceProvider.GetService<IDatabaseInitializer>().InitializeAsync();
            }
            app.UseHttpsRedirection();
            
            app.UseMvc();
            
        }
    }
}
