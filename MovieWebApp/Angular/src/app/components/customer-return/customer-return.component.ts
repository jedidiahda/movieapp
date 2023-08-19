import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerReturn } from 'src/app/models/customer-return.model';
import { Customer } from 'src/app/models/customer.model';
import { DVDCatalog } from 'src/app/models/dvd-catalog.model';
import { CustomerDeliveryService } from 'src/app/services/customer-delivery.service';

@Component({
  selector: 'app-customer-return',
  templateUrl: './customer-return.component.html',
  styleUrls: ['./customer-return.component.css'],
})
export class CustomerReturnComponent implements OnInit {
  customerReturns: CustomerReturn[] = [];
  list: any = [];

  constructor(
    private customerDeliveryService: CustomerDeliveryService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.getDvdStatus();
  }

  getDvdStatus() {
    this.customerDeliveryService
      .getDVDStatus()
      .then((dvdStatus) => {
        //result && (this.customerReturns = result);
        console.log(dvdStatus);
        this.list = [];
        const groupedKeys =
          dvdStatus &&
          dvdStatus.reduce((group: { [key: string]: Customer[] }, item) => {
            if (!group[item.customerId]) {
              group[item.customerId] = [];
            }

            if (
              group[item.customerId].filter((s) => s.id == item.customerId)
                .length == 0
            ) {
              let cust = new Customer();
              cust.firstName = item.customerName;

              group[item.customerId].push(cust);
              let dvds: any[] = [];
              dvdStatus
                .filter((s) => s.customerId == item.customerId)
                .map((s, index) => {
                  dvds.push({
                    title: s.title,
                    code: s.code,
                    dvdCatalogId: s.dvdCatalogId,
                    returnDate: s.returnDate,
                    deliveryDate: s.deliveryDate,
                  });
                });

              this.list.push({
                customerId: item.customerId,
                customerName: item.customerName,
                customerSubscriptionId: item.customerSubscriptionId,
                dvds: dvds,
              });
            }
            return group;
          }, {});
      })
      .catch((err) => console.log(err));
  }

  onReturnClick(subscriptionId: number, code: string, dvdCatalogId: number) {
    this.customerDeliveryService
      .returnDvd(subscriptionId, code, dvdCatalogId)
      .then((result) => {
        this.getDvdStatus();
      })
      .catch((err) => console.log(err));
  }
}
