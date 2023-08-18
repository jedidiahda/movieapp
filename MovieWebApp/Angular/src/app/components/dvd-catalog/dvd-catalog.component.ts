import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DVDCatalog } from 'src/app/models/dvd-catalog.model';
import { DvdCatalogService } from 'src/app/services/dvd-catalog.service';

@Component({
  selector: 'app-dvd-catalog',
  templateUrl: './dvd-catalog.component.html',
  styleUrls: ['./dvd-catalog.component.css'],
})
export class DvdCatalogComponent implements OnInit {
  title:string='';
  constructor(
    private dvdCatalogService: DvdCatalogService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}

  dvdCatalogs: DVDCatalog[] = [];

  ngOnInit(): void {
    this.getAll("",10,1);
  }

  getAll(title: string = '', limit: number = 10, pageNumber: number = 1) {
    this.dvdCatalogService
      .getAll(title, limit, pageNumber)
      .then((dvdCatalog) => dvdCatalog && (this.dvdCatalogs = dvdCatalog));
  }

  deleteOne(dvdCatalogId: string) {
    if (confirm('Are you sure you want to delete?') === true) {
      this.dvdCatalogService
        .deleteOne(dvdCatalogId)
        .then((dvdCatalog) => this.getAll());
    }
  }

  onSearch() {
    this.getAll(this.title,10,1);
  }
}
