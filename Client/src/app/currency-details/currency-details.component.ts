import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.service.getCurrencyInfo(this.route.snapshot.paramMap.get('id')).subscribe(x=>{
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
      this.exchangeInfo = x
    })
  }

}
