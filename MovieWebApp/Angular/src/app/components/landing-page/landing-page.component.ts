import { Component, OnInit } from '@angular/core';
import { Subscription } from 'src/app/models/subscription.model';
import { SubscriptionDataService } from 'src/app/services/subscription-data.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css'],
})
export class LandingPageComponent implements OnInit {
  subscriptions: Subscription[] = [];
  constructor(private subscriptionService: SubscriptionDataService) {}

  ngOnInit(): void {
    this.getSubscriptions();
  }

  getSubscriptions() {
    this.subscriptionService
      .getAll()
      .then((sub) => sub && (this.subscriptions = sub))
      .catch((err) => console.log(err));
  }
}
