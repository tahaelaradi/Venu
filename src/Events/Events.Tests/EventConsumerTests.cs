using System.Linq;
using System.Threading.Tasks;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Venu.BuildingBlocks.Shared.Messaging;
using Venu.Events.API.IntegrationHandlers;

namespace Events.Tests
{
    public class EventConsumerTests
    {
        private ILogger _logger;
        
        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            _logger = factory.CreateLogger<EventCreatedConsumer>();
        }

        [Test]
        public async Task Should_test_the_consumer()
        {
            var harness = new InMemoryTestHarness("amqp://rabbitmq");
            var consumerTestHarness = harness.Consumer<EventCreatedConsumer>();
            
            await harness.Start();
            try
            {
                await harness.InputQueueSendEndpoint.Send<EventCreated>(new
                {
                    Id = "1234",
                    Name = "Testing EventConsumer"
                });
                
                // did the endpoint consume the message
                Assert.IsTrue(harness.Consumed.Select<EventCreated>().Any());
            
                // did the actual consumer consume the message
                Assert.IsTrue(consumerTestHarness.Consumed.Select<EventCreated>().Any());
            }
            finally
            {
                await harness.Stop();
            }
        }
    }
}