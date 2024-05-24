import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CurrencyExchangePopupComponent } from '../shared/currency-exchange-popup/currency-exchange-popup.component';
import { DialogService } from '../shared/services/dialog.service';
import { CurrencyDetailsService } from './currency-details.service';

@Component({
  selector: 'app-currency-details',
  templateUrl: './currency-details.component.html',
  styleUrls: ['./currency-details.component.scss']
})
export class CurrencyDetailsComponent implements OnInit {

  data: any;
  options: any;
  currencyInfo: any;
  exchangeInfo: any;
  constructor(
    private service: CurrencyDetailsService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private dialogService: DialogService
  ) { }

  ngOnInit(): void {
    this.service.getCurrencyInfo(this.route.snapshot.paramMap.get('id')).subscribe(x=>{
      console.log(x)
      this.currencyInfo = x;
      this.data = {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
        datasets: [
          {
            label: `${this.currencyInfo.data.symbol} to PLN`,
            data: [3.76, 3.74, 3.78, 3.71, 3.80, 3.85, 3.82],
            fill: false,
            borderColor: '#4bc0c0'
          }
        ]
      };
      
      this.options = {
        title: {
          display: true,
          text: 'Currency Rate History (Base: PLN)',
          fontSize: 16
        },
        legend: {
          position: 'bottom'
        }
      }
    })
    this.service.getExchangeInfo(this.route.snapshot.paramMap.get('id')).subscribe(x=>{
      console.log(x)
      this.exchangeInfo = x
    })
  }

  exchange(){
   if(localStorage.getItem('token') == null)
      this.toastr.error("Żeby skorzystać z tej funkcji musisz być zalogowany");
    this.dialogService.showDialog()
  }

}
