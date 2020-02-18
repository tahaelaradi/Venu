using System.Linq;
using System.Threading.Tasks;
using MassTransit.Testing;
using NUnit.Framework;
using Venu.Events.IntegrationEvents;
using Venu.Events.IntegrationHandlers;

namespace Events.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Should_test_the_consumer()
        {
            var harness = new InMemoryTestHarness("rabbitmq://localhost/venu/");
            var consumerHarness = harness.Consumer<EventCreatedConsumer>();

            await harness.Start();
            try
            {
                await harness.InputQueueSendEndpoint.Send<EventCreated>(new
                {
                    Name = "Testing EventConsumer"
                });
                
                // did the endpoint consume the message
                Assert.IsTrue(harness.Consumed.Select<EventCreated>().Any());

                // did the actual consumer consume the message
                Assert.IsTrue(consumerHarness.Consumed.Select<EventCreated>().Any());
            }
            finally
            {
                await harness.Stop();
            }
        }
    }
}