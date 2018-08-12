using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroArch.Services.Activities.Domain.Models
{
    public class Category
    {

        public Guid ID { get; protected set; }
        public string Name { get; protected set; }

        protected Category()
        {
        }

        public Category(string name)
        {
            ID = Guid.NewGuid();

            Name = name.ToLowerInvariant();
        }


    }
}
