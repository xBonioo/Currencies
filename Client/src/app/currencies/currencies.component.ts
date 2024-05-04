import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CurrenciesService } from './currencies.service';
import { Currency } from './currency.model';



@Component({
  selector: 'app-currencies',
  templateUrl: './currencies.component.html',
  styleUrls: ['./currencies.component.scss']
})
export class CurrenciesComponent implements OnInit {

  filterText: string;
  currencies: Currency[];

  constructor(
    private currenciesService: CurrenciesService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.currenciesService.getCurrencies().subscribe(x=>{
      this.currencies = x.data.items;
    })
  }

  currencyDetails(currency){
    this.router.navigateByUrl(`${currency.id}`)
  }
}
