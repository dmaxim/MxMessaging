using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mx.Messaging.Models.Events;

namespace Mx.Messaging.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly ILogger<EventsController> _logger;

        public EventsController(ILogger<EventsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Publish(ApplicationEvent eventModel)
        {
            return Ok("Received Event");
        }
    }
}
