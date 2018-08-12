using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroArch.Common.Commands;
using MicroArch.Common.Events;
using RawRabbit;

namespace MicroArch.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {

        private readonly IBusClient _busClient;

        public CreateActivityHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        

        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating Activity:{command.Name}");
            await _busClient.PublishAsync(new ActivityCreated(command.ID, command.UserId, command.Name,
                command.Category, command.Description, command.CreatedAtDate));

        }
    }
}
