import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'src/app/models/subscription.model';
import { SubscriptionDataService } from 'src/app/services/subscription-data.service';

@Component({
  selector: 'app-subscription-form',
  templateUrl: './subscription-form.component.html',
  styleUrls: ['./subscription-form.component.css'],
})
export class SubscriptionFormComponent implements OnInit {
  name: string = '';
  atHomeDVD: number = 0;
  noDVDPerMonth: number = 0;
  price: number = 0;
  subscriptionForm!: FormGroup;
  subscriptionId!: string;

  constructor(
    private subscriptionService: SubscriptionDataService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.subscriptionId = this.activeRoute.snapshot.params['subscriptionId'];

    this.subscriptionForm = new FormGroup({
      name: new FormControl(''),
      atHomeDvd: new FormControl(0),
      noDvdperMonth: new FormControl(0),
      price: new FormControl(0),
    });

    if (this.subscriptionId) {
      this.getOne();
    }
  }

  onSubmit() {
    if (this.subscriptionId) {
      this.subscriptionService
        .updateOne(this.subscriptionId, this.subscriptionForm.value)
        .then((s) => {
          this.router.navigate(['/subscription']);
        });
    } else {
      this.subscriptionService
        .createOne(this.subscriptionForm.value)
        .then((s) => {
          this.router.navigate(['/subscription']);
        });
    }
  }

  getOne() {
    this.subscriptionService
      .getOne(this.subscriptionId)
      .then((s) => s && this.populateDataToControl(s));
  }

  populateDataToControl(subscription: Subscription) {
    this.subscriptionForm = new FormGroup({
      name: new FormControl(subscription.name),
      atHomeDvd: new FormControl(subscription.atHomeDvd),
      noDvdperMonth: new FormControl(subscription.noDvdperMonth),
      price: new FormControl(subscription.price),
    });
  }
}
