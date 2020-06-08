import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Team } from '../../Interfaces/app.interfaces'

@Injectable()

export class TeamsService{

  private _baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this._baseUrl = baseUrl;
  }

  public get(id: number) : Observable<Team> {

    let rtn = this.httpClient.get<Team>(this._baseUrl + 'api/teams/' + id);

    return rtn;

  }
}


