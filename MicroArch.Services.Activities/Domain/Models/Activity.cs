using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroArch.Services.Activities.Domain.Models
{
    public class Activity
    {

        public Guid ID { get; protected set; }
        public string Name { get; protected set; }
        public string Category { get; protected set; }
        public string Description { get; set; }
        public Guid UserID { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        protected Activity()
        {


        }

        public Activity(Guid iD, string name, string category, string description, Guid userID, DateTime createdAt)
        {
            ID = iD;
            Name = name;
            Category = category;
            Description = description;
            UserID = userID;
            CreatedAt = createdAt;
        }
    }
}
