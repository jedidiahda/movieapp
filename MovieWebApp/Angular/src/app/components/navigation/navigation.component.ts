import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { SubscriptionDataService } from 'src/app/services/subscription-data.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  isValidSubscription:boolean = false;
  constructor(public authService:AuthenticationService,public subscriptionService:SubscriptionDataService) { }

  ngOnInit(): void {
    this.getAvailableSubscription();
    console.log(this.authService.customerId)
  }

  getAvailableSubscription(){
    this.subscriptionService.getAvailableScription(parseInt(this.authService.customerId),new Date())
      .then(subscriptions => {
        this.isValidSubscription = subscriptions !== undefined;
      })
      .catch(err => console.log(err));
  }

}
