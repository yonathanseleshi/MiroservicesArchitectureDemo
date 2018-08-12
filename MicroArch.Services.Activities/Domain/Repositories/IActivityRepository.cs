using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroArch.Services.Activities.Domain.Models;

namespace MicroArch.Services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);

        Task AddAsync(Activity activity);
    }
}
