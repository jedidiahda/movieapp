import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { DVDStatus } from '../models/dvd-status.model';

@Injectable({
  providedIn: 'root',
})
export class DvdStatusService {
  basedUrl: string = environment.basedUrl+"/Subscription";
  constructor(private http: HttpClient) {}

  getAll(customerSubId: string): Promise<DVDStatus[] | undefined> {
    return this.http
      .get<DVDStatus[]>(
        `${this.basedUrl}/GetCustomerDvdStatus?customerSubId=${customerSubId}`
      )
      .toPromise();
  }
}
