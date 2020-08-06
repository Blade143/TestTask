import { Component } from '@angular/core';
import {PersonIdAndDateModel} from '../models/idDateRequest';
import {PersonIdAndWeekNumberModel} from '../models/idWeekRequest';
import { HttpClient} from '@angular/common/http';
import { activity } from '../models/activity';

@Component({
  selector: 'activity-component',
  templateUrl: './activity.app.component.html',
  styleUrls: ['./activity.app.component.css']
})
export class ActivityComponent {
  url: string = "http://localhost:49794/api/Activity";

  idDateRequest: PersonIdAndDateModel = new PersonIdAndDateModel();
  idWeekRequest: PersonIdAndWeekNumberModel = new PersonIdAndWeekNumberModel();
  weekActivities: activity[];
  dateactivity: activity[];

  constructor(private http:HttpClient) {}

  GetWeekAktivities(): void{
    this.http.post(this.url+'/GetActionsByIdInWeeks', this.idWeekRequest).subscribe((data: activity[])=> this.weekActivities = data);
  }

  GetDateAktivities(): void{
    this.http.post(this.url+'/GetActionsByNameAndId', this.idDateRequest).subscribe((data: activity[])=> this.dateactivity = data);
  }
}
