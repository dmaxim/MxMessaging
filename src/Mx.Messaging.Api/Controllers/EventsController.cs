using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mx.Messaging.Models.Events;
using Newtonsoft.Json;

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
            LogRequest(eventModel);
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

        private void LogRequest(ApplicationEvent eventModel)
        {
            _logger.LogInformation("******* Request Received ****");
            _logger.LogInformation(JsonConvert.SerializeObject(eventModel));
            _logger.LogInformation("***** End of Request ******");

        }
    }
}
