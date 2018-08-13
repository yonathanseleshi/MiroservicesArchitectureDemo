using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroArch.Services.Activities.Domain.Models;
using MicroArch.Services.Activities.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MicroArch.Services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {

        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            this._database = database;
        }


        public async Task<Activity> GetAsync(Guid id)
            => await Collection.AsQueryable()
                .FirstOrDefaultAsync(x => x.ID == id);

  
        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");

    }
}
