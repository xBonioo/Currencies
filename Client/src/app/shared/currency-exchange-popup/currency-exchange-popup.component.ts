import { Component, OnInit } from '@angular/core';
import { DialogService } from '../services/dialog.service';

@Component({
  selector: 'app-currency-exchange-popup',
  templateUrl: './currency-exchange-popup.component.html',
  styleUrls: ['./currency-exchange-popup.component.scss']
})
export class CurrencyExchangePopupComponent implements OnInit {
  display: boolean = false;
  currencyFrom: string = '';
  fromAmount: number;
  currencyTo: string = '';
  toAmount: number;
  data

  constructor(private dialogService: DialogService) {}

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
    this.hideDialog();
  }
}
