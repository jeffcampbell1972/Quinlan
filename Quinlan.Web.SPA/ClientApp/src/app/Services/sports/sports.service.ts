import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()

export class SportsService{
  public sport: Sport;
  private _baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this._baseUrl = baseUrl;
  }

  public get(id: number) : Observable<Sport> {

    let rtn = this.httpClient.get<Sport>(this._baseUrl + 'api/sports/' + id);

    return rtn;

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

