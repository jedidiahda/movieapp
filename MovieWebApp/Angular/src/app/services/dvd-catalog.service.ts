import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { DVDCatalog } from '../models/dvd-catalog.model';
import { DVDCopy } from '../models/dvd-copy.model';

@Injectable({
  providedIn: 'root',
})
export class DvdCatalogService {
  basedUrl: string = environment.basedUrl + '/DVDCatalog';
  constructor(private http: HttpClient) {}

  createOne(dvdCatalog: DVDCatalog): Promise<DVDCatalog | undefined> {
    dvdCatalog.isDeleted = false;
    return this.http
      .post<DVDCatalog>(`${this.basedUrl}`, dvdCatalog)
      .toPromise();
  }

  getAll(
    title: string,
    limit: number,
    pageNumber: number
  ): Promise<DVDCatalog[] | undefined> {
    return this.http
      .get<DVDCatalog[]>(
        `${this.basedUrl}?title=${title}&limit=${limit}&pageNumber=${pageNumber}`
      )
      .toPromise();
  }

  getOne(dvdCatalogId: string): Promise<DVDCatalog | undefined> {
    return this.http
      .get<DVDCatalog>(`${this.basedUrl}/${dvdCatalogId}`)
      .toPromise();
  }

  updateOne(
    DVDCatalogId: string,
    dvdCatalog: DVDCatalog
  ): Promise<DVDCatalog | undefined> {
    return this.http
      .put<DVDCatalog>(`${this.basedUrl}/${DVDCatalogId}`, dvdCatalog)
      .toPromise();
  }

  deleteOne(dvdCatalogId: string) {
    return this.http
      .delete<DVDCatalog>(`${this.basedUrl}/${dvdCatalogId}`)
      .toPromise();
  }

  addDvdCopy(dvdCatalogId: string, dvdCopy: DVDCopy) {
    dvdCopy.status = 'A';
    return this.http
      .post<DVDCatalog>(`${this.basedUrl}/${dvdCatalogId}/dvdcopy`, dvdCopy)
      .toPromise();
  }

  getDvdCopies(
    dvdCatalogId: string,
    code: string,
    limit: number,
    pageNumber: number
  ): Promise<DVDCopy[] | undefined> {
    return this.http
      .get<DVDCopy[]>(
        `${this.basedUrl}/${dvdCatalogId}/dvdcopy?code=${code}&limit=${limit}&pageNumber=${pageNumber}`
      )
      .toPromise();
  }

  getDvdCopy(dvdCatalogId: string, code: string): Promise<DVDCopy | undefined> {
    return this.http
      .get<DVDCopy>(`${this.basedUrl}/${dvdCatalogId}/dvdcopy/${code}`)
      .toPromise();
  }

  updateDvdCopy(id: string, dvdCopy: DVDCopy) {
    return this.http
      .put<DVDCopy>(`${this.basedUrl}/dvdcopy/${id}`, dvdCopy)
      .toPromise();
  }

  deleteDvdCopy(code: string) {
    return this.http
      .delete<DVDCopy>(`${this.basedUrl}/dvdcopy/${code}`)
      .toPromise();
  }
}
