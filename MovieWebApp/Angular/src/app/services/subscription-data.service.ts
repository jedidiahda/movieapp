import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Subscription } from '../models/subscription.model';
import { CustomerSubscription } from '../models/customer-subscription.model';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionDataService {
  basedUrl: string = environment.basedUrl + '/subscription';
  subscription: CustomerSubscription = new CustomerSubscription();

  constructor(private http: HttpClient) {}

  createOne(subscription: Subscription): Promise<Subscription | undefined> {
    return this.http
      .post<Subscription>(`${this.basedUrl}`, subscription)
      .toPromise();
  }

  getAll(): Promise<Subscription[] | undefined> {
    return this.http.get<Subscription[]>(`${this.basedUrl}`).toPromise();
  }

  getOne(subscriptionId: string): Promise<Subscription | undefined> {
    return this.http
      .get<Subscription>(`${this.basedUrl}/${subscriptionId}`)
      .toPromise();
  }

  updateOne(
    subscriptionId: string,
    subscription: Subscription
  ): Promise<Subscription | undefined> {
    return this.http
      .put<Subscription>(`${this.basedUrl}/${subscriptionId}`, subscription)
      .toPromise();
  }

  deleteOne(subscriptionId: string) {
    return this.http
      .delete<Subscription>(`${this.basedUrl}/${subscriptionId}`)
      .toPromise();
  }

  subscribe(customerSubscription: any) {
    return this.http
      .post<CustomerSubscription>(
        `${this.basedUrl}/subscribe`,
        customerSubscription
      )
      .toPromise();
  }

  getAvailableScription(
    customerId: number,
    date: Date
  ): Promise<CustomerSubscription | undefined> {
    return this.http
      .get<CustomerSubscription>(
        `${
          this.basedUrl
        }/GetAvailableScription?customerId=${customerId}&date=${date.toISOString()}`
      )
      .toPromise();
  }
}
