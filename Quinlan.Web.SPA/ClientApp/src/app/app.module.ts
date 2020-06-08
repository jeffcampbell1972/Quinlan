import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { CollegesService } from './Services/colleges/colleges.service';
import { PeopleService } from './Services/people/people.service';
import { SportsService } from './Services/sports/sports.service';
import { TeamsService } from './Services/teams/teams.service';

import { CollegeComponent } from './Components/college/college.component';
import { PersonComponent } from './Components/person/person.component';
import { SportComponent } from './Components/sport/sport.component';
import { TeamComponent } from './Components/team/team.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CollegeComponent,
    PersonComponent,
    SportComponent,
    TeamComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'college/:id', component: CollegeComponent },
      { path: 'person/:id', component: PersonComponent },
      { path: 'sport/:id', component: SportComponent },
      { path: 'team/:id', component: TeamComponent },
    ])
  ],
  providers: [
    CollegesService,
    PeopleService,
    SportsService,
    TeamsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
