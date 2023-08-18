import { DVDCatalog } from './dvd-catalog.model';

export class Watchlist{
  rank!:number;
  dvdcatalogId!:number;
  customerId!:number;
  dvdcatalog!:DVDCatalog;
}