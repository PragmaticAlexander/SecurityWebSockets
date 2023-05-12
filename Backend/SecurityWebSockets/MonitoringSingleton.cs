using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices.JavaScript;

namespace SecurityWebSockets
{
    public sealed class MonitoringSingleton
    {
        public List<MonitoringEvent> MonitoredEvents { get; }
        public  IObservable<MonitoringEvent>? MonitoringEventObservable; 

        private MonitoringSingleton()
        {
            Console.WriteLine("Activating Monitoring System...");
            this.MonitoredEvents = new List<MonitoringEvent>();

           

            //this.OccurEvent();

            new Thread(LoopMonitor).Start();
        }

        private void LoopMonitor()
        {
            MonitoringEventObservable = Observable.Create<MonitoringEvent>(eventObserver =>
          {
              while (true)
              {
                  Random random = new Random();
                  int timeToWait = random.Next(2, 3) * 1000;

                  Thread.Sleep(timeToWait);

                  MonitoringEvent monitoringEvent = MonitoringSingleton.GetInstance().OccurEvent();
                  eventObserver.OnNext(monitoringEvent);
                  
              }
              return Disposable.Empty;
          }); 

            
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

        public MonitoringEvent OccurEvent()
        {
            MonitoringEvent e = new MonitoringEvent();
            Console.WriteLine($"{e.OccurrenceTime} | {e.Description}");
            MonitoredEvents.Add(e);
            return e;
            
            // used subject because in MonitoredEventsObservable.Next(); you cant put in any arguments. A subject is a mutable observable.
            //MonitoredEventsSubject.OnNext(e);


        }

        public void someBusinessLogic()
        {
            // ...
        }
    }
}
