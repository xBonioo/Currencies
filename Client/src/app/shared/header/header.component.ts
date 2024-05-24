import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  menuItems: MenuItem[];
  loginStr: string;
  passwordStr: string
  
  constructor(
    private appService: AppService,
    private router: Router
  ) {
     this.menuItems = [
  ];
}

  ngOnInit(): void {

  }

  login(){
    this.router.navigateByUrl('login')
  }

  register(){
    this.router.navigateByUrl('register')
  }

  isLoggedIn(){
    return localStorage.getItem('displayName') != null
  }

  getUserName(){
    return localStorage.getItem('displayName');
  }
}
