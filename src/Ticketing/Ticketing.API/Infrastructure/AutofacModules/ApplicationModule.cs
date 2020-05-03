using Autofac;
using Venu.Ticketing.API.Application.Queries;
using Venu.Ticketing.API.Infrastructure.Services;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.AggregatesModel.TicketAggregate;
using Venu.Ticketing.Domain.AggregatesModel.VenueAggregate;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API.Infrastructure.AutofacModules
{

    public class ApplicationModule :Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<EventRepository>()
                .As<IEventRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<VenueRepository>()
                .As<IVenueRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SeatingRepository>()
               .As<ISeatingRepository>()
               .InstancePerLifetimeScope();
            
            builder.RegisterType<TicketRepository>()
                .As<ITicketRepository>()
                .InstancePerLifetimeScope();
            
            builder.Register(c => new VenueQueries(QueriesConnectionString))
                .As<IVenueQueries>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<VenueService>()
                .As<IVenueService>()
                .InstancePerLifetimeScope();
        }
    }
}
