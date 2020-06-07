import { Component } from '@angular/core';
import { SportsService } from '../../Services/sports/sports.service';

@Component({
  selector: 'football',
  templateUrl: './football.component.html'
})
export class FootballComponent {
  public sport: Sport;
  private sub: any;

  constructor(private sports: SportsService)
  {
    this.sports.get(3).subscribe(result => {
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

