import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { MonitoringEvent } from '../models/monitoringEvent';
import { MonitoringEventWebsocketVersion } from '../models/monitoringEventWebsocket';

// type MonitoringEvent = {
//   id: string,
//   occurrenceTime: Date,
//   description: string,
//   imageUrl: string
// }
// type MonitoringEventWebsocketVersion = {
//   Id: string,
//   OccurrenceTime: Date,
//   Description: string,
//   ImageUrl: string
// }

@Component({
  selector: 'app-live-monitor',
  templateUrl: './live-monitor.component.html',
  styleUrls: ['./live-monitor.component.scss']
})
export class LiveMonitorComponent implements OnInit {
  private webSocket!: WebSocket;
  isLoading = true;

  monitoringEvents: MonitoringEvent[] = [];

  constructor(private _http: HttpClient) {}
  
  mapWebsocketProperties(wsEvent: MonitoringEventWebsocketVersion): MonitoringEvent{
    const monitoringEvent = new MonitoringEvent();
    monitoringEvent.id = wsEvent.Id;
    monitoringEvent.occurrenceTime= wsEvent.OccurrenceTime;
    monitoringEvent.description = wsEvent.Description;
    monitoringEvent.imageUrl = wsEvent.ImageUrl;
    
    return monitoringEvent
  }

  GetEventsThatAlreadyHappened():Promise<MonitoringEvent[]>{
    return firstValueFrom<MonitoringEvent[]>(this._http.get<MonitoringEvent[]>("https://localhost:7096/Monitor/eventList"))
  }

  async ngOnInit(): Promise<void> {
    this.monitoringEvents = await this.GetEventsThatAlreadyHappened();
    this.webSocket = new WebSocket(`wss://localhost:7096/Monitor/ws`);

    this.webSocket.onmessage = (event: MessageEvent) => {
      const monitoringEventWSVersion = JSON.parse(event.data) as MonitoringEventWebsocketVersion;
      const monitoringEvent = this.mapWebsocketProperties(monitoringEventWSVersion);
      this.monitoringEvents.push(monitoringEvent);
      this.isLoading = false;
    };
  }

  ngOnDestroy(): void {
  
    this.webSocket.close();
  }
}
