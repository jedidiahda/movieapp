import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CustomerDelivery } from '../models/customer-delivery.model';

@Injectable({
  providedIn: 'root',
})
export class CustomerDeliveryService {
  basedUrl: string = environment.basedUrl + '/CustomerDelivery';
  constructor(private http: HttpClient) {}

  getValidCustomerDelivery(): Promise<CustomerDelivery[] | undefined> {
    return this.http.get<CustomerDelivery[]>(`${this.basedUrl}`).toPromise();
  }

  sendDvdToCustomer(
    subscriptionId: number,
    code: string,
    dvdCatalogId: number
  ) {
    return this.http
      .post(
        `${this.basedUrl}/deliver?subscriptionId=${subscriptionId}&code=${code}&dvdCatalogId=${dvdCatalogId}`,
        {}
      )
      .toPromise();
  }
}
