import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CustomerDelivery } from '../models/customer-delivery.model';
import { DVDStatus } from '../models/dvd-status.model';
import { CustomerReturn } from '../models/customer-return.model';

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

  getDVDStatus():Promise<CustomerReturn[] | undefined>{
    return this.http.get<CustomerReturn[]>(`${this.basedUrl}/DVdStatus`).toPromise();
  }

  returnDvd(
    subscriptionId: number,
    code: string,
    dvdCatalogId: number
  ) {
    return this.http
      .post(
        `${this.basedUrl}/return?subscriptionId=${subscriptionId}&code=${code}&dvdCatalogId=${dvdCatalogId}`,
        {}
      )
      .toPromise();
  }
}
