import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { UserRegister } from './register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  user = new UserRegister()
pesl:string;
  constructor(
    private service: UserService
  ) {}

  ngOnInit(): void {}

  register(){
    this.user.email = "test@mail.pl"
    this.user.confirmPassword = this.user.password
    this.user.identityNumber =  Number.parseInt(this.pesl)
    this.service.registerUser(this.user);
  }
}
