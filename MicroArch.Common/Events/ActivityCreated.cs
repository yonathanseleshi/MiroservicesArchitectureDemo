using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Events
{
    public class ActivityCreated : IAuthenticatedEvent
    {
        public Guid UserID { get;  }
        public Guid ID { get;  }

        public string Name { get;  }

        public string Category { get;  }

        public string Description { get;  }

        public DateTime CreatedAtDate { get;  }

        public ActivityCreated(Guid iD, Guid userId, string name, string category, string description, DateTime createdAtDate)
        {

            UserID = userId;
            ID = iD;
            Name = name;
            Category = category;
            Description = description;
            CreatedAtDate = createdAtDate;
        }

        protected ActivityCreated()
        {
        }
    }
}
