using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroArch.Services.Activities.Domain.Models;

namespace MicroArch.Services.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category);


    }
}
