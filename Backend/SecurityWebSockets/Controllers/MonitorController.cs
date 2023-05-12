using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Text;
using SecurityWebSockets;

namespace SecurityWebSockets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonitorController : ControllerBase
    {
        MonitoringSingleton monitoringSingleton = MonitoringSingleton.GetInstance();

        public MonitorController()
        {

        }
        [HttpGet("eventList")]

        public ActionResult<List<MonitoringEvent>> GetEventList()
        {
            return Ok(monitoringSingleton.MonitoredEvents);
        }

        [HttpGet("ws")]
        public async Task GetMonitor()
        {
           
          

            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using (var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync())
                {
                    if (webSocket.State == WebSocketState.Open)
                    {
                        monitoringSingleton.MonitoringEventObservable.Subscribe(async monitoringEvent =>
                        {
                            var json = JsonSerializer.Serialize(monitoringEvent);
                            await webSocket.SendAsync(Encoding.UTF8.GetBytes(json), WebSocketMessageType.Text, true, CancellationToken.None);
                        });


                    }
                }

                
            }

        }
    }
}     
            
        
    


