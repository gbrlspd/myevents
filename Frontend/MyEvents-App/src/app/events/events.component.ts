import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEvents();
  }

  public getEvents(): void {
    this.http.get('https://localhost:7178/api/events').subscribe(
      (res) => (this.events = res),
      (err) => console.log(err)
    );
  }
}
