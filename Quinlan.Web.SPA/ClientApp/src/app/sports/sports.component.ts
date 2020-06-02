import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'sports',
  templateUrl: './sports.component.html'
})
export class SportsComponent {
  public sport: Sport;

  constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Sport>(baseUrl + 'api/sports/1').subscribe(result => {
      this.sport = result;
    }, error => console.error(error));
  }
}

interface Sport {
  id: number;
  name: string;
  cards: Card[]
}
interface Card {
  id: number;
  year: string;
  companyName: string;
  cardNumber: string;
  rc: string;
  personName: string;
  teamName: string;
}
