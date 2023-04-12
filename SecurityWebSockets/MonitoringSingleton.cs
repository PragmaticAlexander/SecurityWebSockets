using System;

namespace SecurityWebSockets
{
    public sealed class MonitoringSingleton
    {
        public List<MonitoringEvent> MonitoredEvents { get; }

        private MonitoringSingleton() {
            Console.WriteLine("Activating Monitoring System...");
            this.MonitoredEvents = new List<MonitoringEvent>();
            this.OccurEvent();

            while (true)
            {
                Random random = new Random();
                int timeToWait = random.Next(10, 11) * 1000;

                Thread.Sleep(timeToWait);

                OccurEvent();
            }
        }

        private static MonitoringSingleton _instance;

        public static MonitoringSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MonitoringSingleton();
            }
            return _instance;
        }

        private void OccurEvent()
        {
            MonitoringEvent e = new MonitoringEvent();
            Console.WriteLine($"{e.OccuranceTime} | {e.Description}");
            MonitoredEvents.Add(e );
        }

        public void someBusinessLogic()
        {
            // ...
        }
    }
}
