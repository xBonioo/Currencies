import { Component, OnInit } from '@angular/core';
import { CurrencyDetailsService } from 'src/app/currency-details/currency-details.service';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-currency-exchange-popup',
  templateUrl: './currency-exchange-popup.component.html',
  styleUrls: ['./currency-exchange-popup.component.scss']
})
export class CurrencyExchangePopupComponent implements OnInit {
  display: boolean = false;
  currencyFrom: string = '';
  fromAmount: number = 0;
  currencyTo: string = '';
  toAmount: number;
  data

  constructor(
    private dialogService: DialogService,
    private currencyDetailsService: CurrencyDetailsService
  ) { }

  ngOnInit() {
    this.dialogService.displayDialog$.subscribe(show => {
      this.display = show;
    });

    this.dialogService.data$.subscribe(data => {
      this.data = data
      this.currencyFrom = this.data?.Data.Item1.FromCurrency.Symbol
      this.currencyTo = this.data?.Data.Item1.ToCurrency.Symbol
      console.log(this.data)
    });
  }

  hideDialog() {
    this.dialogService.hideDialog();
  }

  exchangeCurrency() {
    console.log(`Exchanging from ${this.currencyFrom} to ${this.currencyTo}`);
    this.currencyDetailsService.ExchangeCurrency({userId: localStorage.getItem('id'),  fromCurrencyId: this.data.Data.Item1.FromCurrency.Id, toCurrencyId: this.data.Data.Item1.ToCurrency.Id, amount: this.fromAmount}).subscribe(
      x=> console.log(x)
    )
    this.hideDialog();
  }
}
