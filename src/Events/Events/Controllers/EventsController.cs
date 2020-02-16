using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Venu.Events.Commands;
using Venu.Events.Queries;

namespace Venu.Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        // GET api/events
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new FindAllEventsQuery());
            return new JsonResult(result);
        }
        
        // POST api/events
        [HttpPost]
        public async Task<ActionResult> PostDraft([FromBody] CreateEventDraftCommand request)
        {
            var result = await _mediator.Send(request);
            return new JsonResult(result);
        }
    }
}