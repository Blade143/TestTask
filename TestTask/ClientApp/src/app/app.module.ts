import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import { ActivityComponent } from './ActivityComponent/activity.app.component';
import { ProjectComponent } from './ProjectComponent/project.app.component';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    ActivityComponent,
    ProjectComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
