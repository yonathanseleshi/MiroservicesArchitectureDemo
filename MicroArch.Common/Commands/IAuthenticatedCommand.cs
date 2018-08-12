using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {

        Guid UserId { get; set; }
    }
}
