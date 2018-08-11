using System;
using System.Collections.Generic;
using System.Text;

namespace MicroArch.Common.Commands
{
    public class CreateActivity : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }

        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAtDate { get; set; }

    }
}
