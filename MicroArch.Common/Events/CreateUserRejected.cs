﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Events
{
    class CreateUserRejected : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        public string Email { get; }

        protected CreateUserRejected()
        {
        }

        public CreateUserRejected(string reason, string code, string email)
        {
            Reason = reason;
            Code = code;
            Email = email;
        }
    }
}
