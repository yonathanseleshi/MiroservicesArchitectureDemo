using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Events
{
    class UserAuthenticated : IEvent
    {

        public string Email { get; }

        public UserAuthenticated(string email)
        {
            Email = email;
        }

        protected UserAuthenticated()
        {
        }
    }
}
