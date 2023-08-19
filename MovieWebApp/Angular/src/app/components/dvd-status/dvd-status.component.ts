import { Component, OnInit } from '@angular/core';
import { DVDStatus } from 'src/app/models/dvd-status.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DvdStatusService } from 'src/app/services/dvd-status.service';
import { SubscriptionDataService } from 'src/app/services/subscription-data.service';

@Component({
  selector: 'app-dvd-status',
  templateUrl: './dvd-status.component.html',
  styleUrls: ['./dvd-status.component.css'],
})
export class DvdStatusComponent implements OnInit {
  dvdStatuses: DVDStatus[] = [];
  constructor(
    private dvdStatusService: DvdStatusService,
    private subscriptionService: SubscriptionDataService,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.getAvailableSubscription();
  }

  getAll(subscriptId:string) {
    this.dvdStatusService
      .getAll(subscriptId)
      .then((result) => result && (this.dvdStatuses = result))
      .catch((err) => console.log(err));
  }

  getAvailableSubscription() {
    this.subscriptionService
      .getAvailableScription(parseInt(this.authService.customerId), new Date())
      .then((subscriptions) => {
        subscriptions && this.getAll(subscriptions?.id);
        //console.log(subscriptions)
      })
      .catch((err) => console.log(err));
  }
}
