import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any = [];
  public filteredEvents: any = [];

  imgWidth: number = 160;
  showImg: boolean = true;

  private _listFilter: string = '';

  public get listFilter(): string {
    return this._listFilter;
  }

  public set listFilter(value: string) {
    this._listFilter = value;
    this.filteredEvents = this.listFilter
      ? this.filterEvents(this.listFilter)
      : this.events;
  }

  filterEvents(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: { theme: string; place: string }) =>
        event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        event.place.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getEvents();
  }

  toggleImg() {
    this.showImg = !this.showImg;
  }

  public getEvents(): void {
    this.http.get('https://localhost:7178/api/events').subscribe(
      (res) => {
        this.events = res;
        this.filteredEvents = this.events;
      },
      (err) => console.log(err)
    );
  }
}
