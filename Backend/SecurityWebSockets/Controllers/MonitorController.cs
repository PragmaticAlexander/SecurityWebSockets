using Microsoft.AspNetCore.Mvc;

namespace SecurityWebSockets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonitorController: ControllerBase
    {
        [HttpGet("LiveMonitor")]
        public IEnumerable<MonitoringEvent> GetMonitor()
        {
            return MonitoringSingleton.GetInstance().MonitoredEvents;
        }
    }
}
