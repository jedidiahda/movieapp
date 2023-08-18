import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DVDCatalog } from 'src/app/models/dvd-catalog.model';
import { DvdCatalogService } from 'src/app/services/dvd-catalog.service';

@Component({
  selector: 'app-dvd-catalog-form',
  templateUrl: './dvd-catalog-form.component.html',
  styleUrls: ['./dvd-catalog-form.component.css']
})
export class DvdCatalogFormComponent implements OnInit {
  title: string = '';
  description: string = '';
  genre: string = '';
  language: string = '';
  noDisk: number = 0;
  stockQty: number = 0;
  releasedDate: Date = new Date();
  
  dvdCatalogForm!: FormGroup;
  dvdCatalogId!: string;

  constructor(
    private dvdCatalogService: DvdCatalogService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}
  
  ngOnInit(): void {
    this.dvdCatalogId = this.activeRoute.snapshot.params['dvdCatalogId'];

    this.dvdCatalogForm = new FormGroup({
      title: new FormControl(''),
      description: new FormControl(''),
      genre: new FormControl(''),
      language: new FormControl(''),
      noDisk: new FormControl(0),
      stockQty: new FormControl(0),
      releasedDate: new FormControl(new Date()),
    });

    if (this.dvdCatalogId) {
      this.getOne();
    }
  }

  onSubmit() {
    if (this.dvdCatalogId) {
      this.dvdCatalogService
        .updateOne(this.dvdCatalogId, this.dvdCatalogForm.value)
        .then((s) => {
          this.router.navigate(['/dvdcatalog']);
        }).catch(err => console.log(err))
    } else {
      this.dvdCatalogService
        .createOne(this.dvdCatalogForm.value)
        .then((s) => {
          this.router.navigate(['/dvdcatalog']);
        });
    }
  }

  getOne() {
    this.dvdCatalogService
      .getOne(this.dvdCatalogId)
      .then((s) => s && this.populateDataToControl(s));
  }

  populateDataToControl(dvdCatalog: DVDCatalog) {
    this.dvdCatalogForm = new FormGroup({
      title: new FormControl(dvdCatalog.title),
      description: new FormControl(dvdCatalog.description),
      genre: new FormControl(dvdCatalog.genre),
      language: new FormControl(dvdCatalog.language),
      noDisk: new FormControl(dvdCatalog.noDisk),
      stockQty: new FormControl(dvdCatalog.stockQty),
      releasedDate: new FormControl(formatDate(new Date(dvdCatalog.releasedDate).toDateString(),"yyyy-MM-dd","en-us"))
    });


  }

}
