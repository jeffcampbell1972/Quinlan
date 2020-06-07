import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SportsService } from './Services/sports/sports.service';
import { BaseballComponent } from './Components/baseball/baseball.component';
import { BasketballComponent } from './Components/basketball/basketball.component';
import { FootballComponent } from './Components/football/football.component';
import { HockeyComponent } from './Components/hockey/hockey.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BaseballComponent,
    BasketballComponent,
    FootballComponent,
    HockeyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'cards/baseball', component: BaseballComponent },
      { path: 'cards/basketball', component: BasketballComponent },
      { path: 'cards/football', component: FootballComponent },
      { path: 'cards/hockey', component: HockeyComponent },
    ])
  ],
  providers: [
    SportsService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
