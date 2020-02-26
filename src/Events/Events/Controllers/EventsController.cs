using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Venu.Events.Commands;
using Venu.Events.Queries;

namespace Venu.Events.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBusControl _bus;
        private readonly ILogger<EventsController> _logger;

        public EventsController(IMediator mediator, 
            IBusControl bus,
            ILogger<EventsController> logger)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._bus = bus;
            _logger = logger;
        }
        
        // GET /events
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new FindAllEventsQuery());
            return new JsonResult(result);
        }
        
        // POST /events
        [HttpPost]
        public async Task<ActionResult> PostDraft([FromBody] CreateEventCommand request)
        {
            var result = await _mediator.Send(request);
            return new JsonResult(result);
        }
    }
}