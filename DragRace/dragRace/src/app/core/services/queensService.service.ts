import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ENV } from '@env/environment.prod';
import { Observable } from 'rxjs';
import { IQueens } from '@core/models/queens.interface';


@Injectable({
  providedIn: 'root'
})

export class QueensService {

  private apiUrl: string = ENV.API.URL + '/';

  constructor(private http: HttpClient) { }

  getAllQueens(): Observable<IQueens[]> {
    return this.http.get<IQueens[]>(this.apiUrl + 'queens/all');
  }
}
