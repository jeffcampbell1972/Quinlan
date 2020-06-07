import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'sports',
  templateUrl: './sports.component.html'
})
export class SportsComponent implements OnInit, OnDestroy {
  public sport: Sport;
  private sub: any;
  id: number;
  url: string;
  http: HttpClient;

  constructor(httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute)
  {
    this.http = httpClient;
    this.url = baseUrl;
  }

  ngOnInit()
  {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

      this.http.get<Sport>(this.url + 'api/sports/' + this.id).subscribe(result => {
        this.sport = result;
      }, error => console.error(error));

    }); 
  }
  ngOnDestroy()
  {
    this.sub.unsubscribe();
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

