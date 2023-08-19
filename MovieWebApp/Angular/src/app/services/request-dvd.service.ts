import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { RequestedDVD } from '../models/requested-dvd.model';

@Injectable({
  providedIn: 'root'
})
export class RequestDVDService {
  basedUrl: string = environment.basedUrl + '/RequestDVD';

  constructor(private http: HttpClient) {}

  getAll(customerId:string){
    return this.http.get<RequestedDVD[]>(`${this.basedUrl}/?customerId=${customerId}`).toPromise();
  }

  deleteOne(requestId:number){
    return this.http
    .delete(`${this.basedUrl}?requestId=${requestId}`)
    .toPromise();
  }

  createOne(requestedDvd:RequestedDVD):Promise<RequestedDVD | undefined>{
    return this.http
    .post<RequestedDVD>(`${this.basedUrl}`, requestedDvd)
    .toPromise();
  }
}
