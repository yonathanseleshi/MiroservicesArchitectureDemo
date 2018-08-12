using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MicroArch.Common.Commands;
using MicroArch.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Common;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using RawRabbit.Pipe.Middleware;
using RawRabbit.vNext;

namespace MicroArch.Common.RabbitMQ
{
    public static class Extensions
    {

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler)
            where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler)
            where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            /*
          var connectionString = configuration.GetConnectionString("rabbitmq");
          var config = ConnectionStringParser.Parse(connectionString);
          var client = BusClientFactory.CreateDefault(config);
            */

            var options = new RabbitMqOptions();
           var section = configuration.GetSection("rabbitmq");

           section.Bind(options);
           var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
           {


               ClientConfiguration = options

           });
            

            service.AddSingleton<IBusClient>(_ => client);
         
        }
    }
}

