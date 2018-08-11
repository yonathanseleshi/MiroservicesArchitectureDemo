using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
        Guid UserID { get;  }
    }
}
