using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Events
{
    public class UserCreated : IEvent
    {

        public string Email { get; }
        public string UserName { get; }

        public UserCreated(string email, string userName)
        {
            Email = email;
            UserName = userName;
        }

        protected UserCreated()
        {
        }
    }
}
