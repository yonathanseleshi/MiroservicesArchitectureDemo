﻿using System;
using System.Collections.Generic;
using System.Text;
using MicroArch.Common.Commands;
using MicroArch.Common.Events;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RawRabbit;

namespace MicroArch.Common.Services
{
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }


        public void Run() => _webHost.Run();


        public static HostBuilder Create<TStartup>(String[] args) where TStartup : class
        {
            Console.Title = typeof(TStartup).Namespace;
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());



        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;

            private IBusClient _bus;

            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UseRabbitMQ()
            {
                _bus = (IBusClient) _webHost.Services.GetService(typeof(IBusClient));

                return new BusBuilder(_webHost, _bus);
            }

            public override ServiceHost Build()
            {

                return new ServiceHost(_webHost);
                
            }

            public class BusBuilder : BuilderBase
            {
                private readonly IWebHost _webHost;

                private IBusClient _bus;

                public BusBuilder(IWebHost webHost, IBusClient bus)
                {
                    _webHost = webHost;
                    _bus = bus;
                }

                public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
                {
                    var handler = (ICommandHandler<TCommand>)_webHost.Services
                        .GetService(typeof(ICommandHandler<TCommand>));

                    _bus.WithCommandHandlerAsync(handler);

                    return this;

                }

                public BusBuilder SubscribeToCommand<TEvent>() where TEvent : IEvent
                {
                    var handler = (IEventHandler<TEvent>)_webHost.Services
                        .GetService(typeof(ICommandHandler<TEvent>));

                    _bus.WithEventHandlerAsync(handler);

                    return this;

                }

                public override ServiceHost Build()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
