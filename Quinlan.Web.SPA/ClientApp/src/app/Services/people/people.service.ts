import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../../Interfaces/app.interfaces'

@Injectable()

export class PeopleService{
  private _baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this._baseUrl = baseUrl;
  }

  public get(id: number): Observable<Person> {

    let response = this.httpClient.get<Person>(this._baseUrl + 'api/people/' + id);

    return response;

  }
}



