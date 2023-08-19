import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CustomerSubscription } from 'src/app/models/customer-subscription.model';
import { Payment } from 'src/app/models/payment.model';
import { SubscriptionDataService } from 'src/app/services/subscription-data.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
})
export class PaymentComponent implements OnInit {
  subscription: CustomerSubscription = new CustomerSubscription();
  bankName: string = '';
  bankLink: string = '';
  amount: number = 0;
  billingAddress: string = '';
  constructor(
    private subscriptionService: SubscriptionDataService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.subscription = this.subscriptionService.subscription;
    console.log(this.subscriptionService.subscription.name);
  }

  onBankChange() {
    switch (this.bankName) {
      case '1':
        this.bankLink = 'https://www.chase.com/';
        break;
      case '2':
        this.bankLink = 'https://www.midwestone.bank/';
        break;
      case '3':
        this.bankLink = 'https://www.wellsfargo.com/';
        break;
    }
  }

  onSubmit() {
    var today = new Date();
    today.setDate(today.getDay() + 30);
    var nextMonth = today;
    var payment = new Payment();
    payment.amount = this.amount;
    payment.paymentDate = new Date();
    payment.paymentType = 1;
    payment.billingAddress = this.billingAddress;
    this.subscriptionService
      .subscribe({
        id: 0,
        SubscriptId: this.subscription.subscriptId,
        customerId: this.subscription.customerId,
        startDate: new Date(),
        endDate: nextMonth,
        payment: payment,
      })
      .then((s) => {
        this.router.navigate(['/home']);
      })
      .catch((err) => console.log(err));
  }
}
