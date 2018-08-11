﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Commands
{
    public class CreateUser : ICommand
    {

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
