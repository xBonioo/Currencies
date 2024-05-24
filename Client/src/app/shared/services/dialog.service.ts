import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DialogService {
  private displayDialogSource = new BehaviorSubject<boolean>(false);
  displayDialog$ = this.displayDialogSource.asObservable();

  showDialog() {
    this.displayDialogSource.next(true);
  }

  hideDialog() {
    this.displayDialogSource.next(false);
  }
}