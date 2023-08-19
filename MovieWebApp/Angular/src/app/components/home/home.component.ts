import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerSubscription } from 'src/app/models/customer-subscription.model';
import { DVDCatalog } from 'src/app/models/dvd-catalog.model';
import { Subscription } from 'src/app/models/subscription.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DvdCatalogService } from 'src/app/services/dvd-catalog.service';
import { SubscriptionDataService } from 'src/app/services/subscription-data.service';
import { WatchlistService } from 'src/app/services/watchlist.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  subscriptions: Subscription[] = [];
  dvdCatalogs: DVDCatalog[] = [];
  isValidSubscription: boolean = false;

  constructor(
    private subscriptionService: SubscriptionDataService,
    private authService: AuthenticationService,
    private dvdService: DvdCatalogService,
    private wathclistService: WatchlistService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    console.log(this.authService.userRole);
    if (this.authService.userRole == 'user') {
      this.getAvailableSubscription();
    }
  }

  getSubscriptions() {
    this.subscriptionService
      .getAll()
      .then((sub) => sub && (this.subscriptions = sub))
      .catch((err) => console.log(err));
  }
  onSubscribeClick(subsciptionId: string, name: string, price: number) {
    this.subscriptionService.subscription.customerId =
      this.authService.customerId;
    this.subscriptionService.subscription.subscriptId = subsciptionId;
    this.subscriptionService.subscription.name = name;
    this.subscriptionService.subscription.price = price;

    this.router.navigate(['/payment']);
  }

  getAvailableSubscription() {
    this.subscriptionService
      .getAvailableScription(parseInt(this.authService.customerId), new Date())
      .then((subscriptions) => {
        this.isValidSubscription = subscriptions !== undefined;
        if (!this.isValidSubscription) {
          this.getSubscriptions();
        } else {
          this.getDVDCatalogs();
        }
      })
      .catch((err) => console.log(err));
  }

  getDVDCatalogs() {
    this.dvdService
      .getAll('', 10, 1)
      .then((dvdCatalogs) => dvdCatalogs && (this.dvdCatalogs = dvdCatalogs));
  }

  onAddToWatchlist(id: string) {
    this.wathclistService
      .createOne(parseInt(this.authService.customerId), parseInt(id))
      .then((s) => alert('added to watchlist'))
      .catch((err) => console.log(err));
  }
}
