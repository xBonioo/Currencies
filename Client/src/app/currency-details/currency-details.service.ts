import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


class Data {
  data: any;
}

@Injectable({
  providedIn: 'root',
})
export class CurrencyDetailsService {
  private apiUrl = 'https://localhost:7050/api/';

  constructor(private http: HttpClient) { }
  
  getCurrencyInfo(id){
    return this.http.get<Data>(`${this.apiUrl}currency/${id}`)
  }

  getExchangeInfo(id){
    return this.http.get<Data>(`${this.apiUrl}exchange/from/4/to/${id}`)
  }
}
