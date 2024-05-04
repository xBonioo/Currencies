import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  login: string;
  password: string;
  constructor(
    private userService: UserService
  ) { }
  
  ngOnInit(): void {
  }

  loginUser(){
    this.userService.loginUser(this.login, this.password);
  }
}
