import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';

type MonitoringEvent = {
  id: string,
  occuranceTime: Date,
  description: string,
  imageUrl: string
}

@Component({
  selector: 'app-live-monitor',
  templateUrl: './live-monitor.component.html',
  styleUrls: ['./live-monitor.component.scss']
})
export class LiveMonitorComponent implements OnInit {

  MonitoringEvents: MonitoringEvent[] = [];

  constructor(private http: HttpClient){
  }

  async ngOnInit(): Promise<void> {
    //get data
    const result = await firstValueFrom(this.http.get('https://localhost:7096/Monitor/LiveMonitor'));
    console.log(result);
  }

}
