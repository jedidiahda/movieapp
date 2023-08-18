import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'src/app/models/subscription.model';
import { SubscriptionDataService } from 'src/app/services/subscription-data.service';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css']
})
export class SubscriptionComponent implements OnInit {
  constructor(private subscriptionService:SubscriptionDataService,
    private activeRoute:ActivatedRoute,
    private router:Router){}

    subscriptions: Subscription[] = [];

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.subscriptionService
      .getAll()
      .then((subscription) => subscription && (this.subscriptions = subscription));
  }

  deleteOne(subscriptionId: string) {
    if (confirm('Are you sure you want to delete?') === true) {
      this.subscriptionService
        .deleteOne(subscriptionId)
        .then((subscription) => this.getAll());
    }
  }
}
