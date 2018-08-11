using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Commands
{
    interface IAuthenticatedCommand : ICommand
    {

        Guid UserId { get; set; }
    }
}
