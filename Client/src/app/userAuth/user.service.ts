import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';

class Data {
  data: any;
}

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'https://localhost:7050/api/';

  constructor(private http: HttpClient, private authService: AuthService) {}

  loginUser(login, password) {
    return this.http
      .post<Data>(`${this.apiUrl}user/signin`, {
        username: login,
        password: password,
      })
      .subscribe((x) => {
        this.authService.setToken(x.data.accessToken);
      });
  }
}
