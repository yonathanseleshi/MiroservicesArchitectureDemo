using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Events
{
    interface IRejectedEvent
    {

        string Reason { get; }
        string Code { get; }
    }
}
