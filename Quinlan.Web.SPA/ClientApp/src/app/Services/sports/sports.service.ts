import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sport } from '../../Interfaces/sport.interface'

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



