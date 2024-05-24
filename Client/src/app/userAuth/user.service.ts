import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { UserRegister } from './register/register.model';

class Data {
  data: any;
}

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'https://localhost:7050/api/';

  constructor(private http: HttpClient) { }

  loginUser(login, password) {
    return this.http.post<Data>(`${this.apiUrl}user/signin`, {
        username: login,
        password: password,
      })
  }

  getUserInfo(id) {
    return this.http.post<Data>(`${this.apiUrl}user/get-user`, {
      userId: id
    })
  }

  registerUser(registerForm: UserRegister) {
    console.log(registerForm)
    return this.http.post<Data>(`${this.apiUrl}user/register`, registerForm)
  }
}
