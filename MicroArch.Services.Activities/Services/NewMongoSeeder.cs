using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroArch.Common.Mongo;
using MicroArch.Services.Activities.Domain.Models;
using MicroArch.Services.Activities.Domain.Repositories;
using MongoDB.Driver;

namespace MicroArch.Services.Activities.Services
{
    public class NewMongoSeeder : MongoSeeder
    {
        private readonly ICategoryRepository _categoryRepository;

        public NewMongoSeeder(IMongoDatabase database,
            ICategoryRepository categoryRepository) : base(database)
        {
            _categoryRepository = categoryRepository;
        }


        protected override async Task CustomSeedAsync()
        {
            var categories = new List<string>
            {
                "work",
                "sport",
                "hobby"

            };
            await Task.WhenAll(categories.Select(x =>
                _categoryRepository.AddAsync(new Category(x))));

        }
    }
}
