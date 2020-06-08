import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { College } from '../../Interfaces/college.interface'

@Injectable()

export class CollegesService{

  private _baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this._baseUrl = baseUrl;
  }

  public get(id: number) : Observable<College> {

    let rtn = this.httpClient.get<College>(this._baseUrl + 'api/colleges/' + id);

    return rtn;

  }
}



