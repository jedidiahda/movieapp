import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Watchlist } from '../models/watchlist.model';

@Injectable({
  providedIn: 'root'
})
export class WatchlistService {

  basedUrl: string = environment.basedUrl + '/Watchlist';
  
  constructor(private http: HttpClient) {}

  createOne(customerId: number,dvdCatalogId:number) {
    return this.http.post(`${this.basedUrl}`, {
      DvdcatalogId:dvdCatalogId,
      CustomerId:customerId,
      Rank:1
    }).toPromise();
  }

  
  getAll(customerId:number): Promise<Watchlist[] | undefined> {
    return this.http.get<Watchlist[]>(`${this.basedUrl}/GetAll?customerId=${customerId}`).toPromise();
  }

  getOne(customerId:number,watchlistId:number): Promise<Watchlist | undefined> {
    return this.http.get<Watchlist>(`${this.basedUrl}?customerId=${customerId}&watchlistId=${watchlistId}`).toPromise();
  }

  updateOne(
    customerId:number,
    dvdcatalogId:number,
    rank:number
  ): Promise<Watchlist | undefined> {
    return this.http.put<Watchlist>(
      `${this.basedUrl}/UpdateRank?customerId=${customerId}&dvdcatalogId=${dvdcatalogId}&rank=${rank}`,
      {}
    ).toPromise();
  }

  deleteOne(customerId:number,dvdcatalogId:number){
    return this.http.delete(
      `${this.basedUrl}?customerId=${customerId}&dvdcatalogId=${dvdcatalogId}`).toPromise();
  }

}
