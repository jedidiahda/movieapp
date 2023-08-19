import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as _ from 'lodash';
import { CustomerDelivery } from 'src/app/models/customer-delivery.model';
import { Customer } from 'src/app/models/customer.model';
import { DVDCatalog } from 'src/app/models/dvd-catalog.model';
import { CustomerDeliveryService } from 'src/app/services/customer-delivery.service';

@Component({
  selector: 'app-customer-delivery',
  templateUrl: './customer-delivery.component.html',
  styleUrls: ['./customer-delivery.component.css']
})
export class CustomerDeliveryComponent implements OnInit {
  customers:Customer[] = [];
  dvdCatalogs:DVDCatalog[] = [];
  list:any=[];

  constructor(private customerDeliveryService:CustomerDeliveryService,
    private activeRoute:ActivatedRoute,
    private router:Router){

  }
  
  ngOnInit(): void {
    this.getValidCustomerDelivery();
  }

  getValidCustomerDelivery(){
    this.customerDeliveryService.getValidCustomerDelivery()
    .then(custDel => {
      this.list = [];
      const groupedKeys = custDel && custDel.reduce((group: {[key: string]: Customer[]}, item) => {
        if (!group[item.customerId]) {
         group[item.customerId] = [];
        }

        if(group[item.customerId].filter(s => s.id == item.customerId).length == 0){
          let cust = new Customer();
          cust.firstName = item.firstName;
          cust.lastName = item.lastName;
          cust.id = item.customerId;
          
          group[item.customerId].push(cust);
          let dvds: any[] = [];
          custDel.filter(s => s.customerId == item.customerId).map( (s,index) => {
            dvds.push({
              title:s.title,
              rank:s.rank,
              code:s.code,
              dvdCatalogId:s.dvdCatalogId
            });
          });

          this.list.push({
            customerId:item.customerId,
            firstName:item.firstName,
            lastName:item.lastName,
            customerSubscriptionId:item.customerSubscriptionId,
            dvds:dvds
          });
        }
        return group;
       }, {});
    })
    .catch(err => console.log(err));
  }

  onSendClick(subscriptionId:number,code:string,dvdCatalogId:number){
    this.customerDeliveryService.sendDvdToCustomer(subscriptionId,code,dvdCatalogId).then(result =>{
      this.getValidCustomerDelivery();
    })
    .catch(err=> console.log(err));
  }


}
