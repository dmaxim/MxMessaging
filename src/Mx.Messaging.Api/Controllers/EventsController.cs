using System;
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
            LogHeaders();
            return Ok("Received Event");
        }

        private void LogHeaders()
        {
            _logger.LogInformation("***********Logging headers**************");
            foreach (var requestHeader in Request.Headers)
            {
                if(!requestHeader.Key.Contains("cookie", StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogInformation($"{requestHeader.Key} value: {requestHeader.Value}");
                }
               
            }

        }
    }
}
