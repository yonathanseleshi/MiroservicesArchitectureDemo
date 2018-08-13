﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RawRabbit.Instantiation;

namespace MicroArch.Common.Mongo
{
    public static class Extensions
    {


        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<MongoOptions>(configuration.GetSection("mongo"));
            services.AddSingleton<MongoClient>(c =>
            {

                var options = c.GetService<IOptions<MongoOptions>>();

                return new MongoClient(options.Value.ConnectionString);

            });


            services.AddScoped<IMongoDatabase>(c =>
            {

                var options = c.GetService<IOptions<MongoOptions>>();
                var client = c.GetService<MongoClient>();
                return client.GetDatabase(options.Value.Database);

            });

            services.AddScoped<IDatabaseInitializer, MongoInitialize>();
            services.AddScoped<IDatabaseSeeder, MongoSeeder>();

        }
    }
}
