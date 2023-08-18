import { DVDCatalog } from './dvd-catalog.model';

export interface CustomerDelivery{
  customerId:string;
  firstName:string; 
  lastName:string; 
  customerSubscriptionId:number;
  title:string;
  rank:number;
  code:string;
  dvdCatalogId:number;
}