import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CurrenciesComponent } from './currencies/currencies.component';
import { CurrencyDetailsComponent } from './currency-details/currency-details.component';
import { LoginComponent } from './userAuth/login.component';
import { RegisterComponent } from './userAuth/register.component';

const routes: Routes = [
  {path: '', component: CurrenciesComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: ':id', component: CurrencyDetailsComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
