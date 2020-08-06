import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  projectcomp: boolean = false;
  activitycomp: boolean = false;

  Project(): void {
    this.projectcomp = true;
    this.activitycomp = false;
  }

  Activity(): void {
    this.projectcomp = false;
    this.activitycomp = true;
  }
}
