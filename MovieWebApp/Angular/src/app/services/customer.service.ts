import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  basedUrl: string = environment.basedUrl + '/Customer';
  constructor(private http: HttpClient) {}

  createOne(customer: Customer): Promise<Customer | undefined> {
    return this.http
      .post<Customer>(`${this.basedUrl}`, customer)
      .toPromise();
  }

}
