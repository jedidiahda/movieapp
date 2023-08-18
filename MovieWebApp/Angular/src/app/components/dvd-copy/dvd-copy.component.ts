import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DVDCopy } from 'src/app/models/dvd-copy.model';
import { DvdCatalogService } from 'src/app/services/dvd-catalog.service';

@Component({
  selector: 'app-dvd-copy',
  templateUrl: './dvd-copy.component.html',
  styleUrls: ['./dvd-copy.component.css'],
})
export class DvdCopyComponent implements OnInit {
  dvdCopies: DVDCopy[] = [];
  dvdCatalogId: string = '';
  code: string = '';
  dvdCopyForm!: FormGroup;
  search:string='';


  constructor(
    private dvdCatalogService: DvdCatalogService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.dvdCatalogId = this.activeRoute.snapshot.params['dvdCatalogId'];
    this.dvdCopyForm = new FormGroup({
      code: new FormControl(''),
      id: new FormControl(''),
      status:new FormControl(''),
    });

    this.getAll(this.dvdCatalogId,'', 10, 1);
  }

  getAll(dvdCatalogId: string,code:string, limit: number, pageNumber: number) {
    this.dvdCatalogService
      .getDvdCopies(dvdCatalogId,code, limit, pageNumber)
      .then((dvdCopies) => dvdCopies && (this.dvdCopies = dvdCopies))
      .catch((err) => console.log(err));
  }

  onSubmit() {
    if(this.dvdCopyForm.get('id')?.value != ''){
      this.update();
    }else{
      this.save();
    }

  }

  update(){
    this.dvdCatalogService
    .getDvdCopy(this.dvdCatalogId, this.dvdCopyForm.get('code')?.value)
    .then((dvdCopy) => {
      if (dvdCopy) {
        alert('Code is in used');
      } else {
        console.log(this.dvdCopyForm.value);
        this.dvdCatalogService
          .updateDvdCopy(this.dvdCopyForm.get('id')?.value, this.dvdCopyForm.value)
          .then((dvdCopy) => this.getAll(this.dvdCatalogId,'', 10, 1));
      }
    })
    .catch(err => console.log(err));
  }

  save(){
    this.dvdCatalogService
    .getDvdCopy(this.dvdCatalogId, this.dvdCopyForm.get('code')?.value)
    .then((dvdCopy) => {
      if (dvdCopy) {
        alert('Code is in used');
      } else {
        let dvdCopy = new DVDCopy();
        dvdCopy.id ='0';
        dvdCopy.code =this.dvdCopyForm.get('code')?.value;
        dvdCopy.status='A';
        dvdCopy.dvdcatalogId= parseInt(this.dvdCatalogId);
        dvdCopy.isDeleted=false;
        this.dvdCatalogService
          .addDvdCopy(this.dvdCatalogId, dvdCopy)
          .then((dvdCopy) => this.getAll(this.dvdCatalogId,'', 10, 1));
      }
    });
  }

  getDvdCopy(code: string) {
    this.dvdCatalogService
      .getDvdCopy(this.dvdCatalogId, code)
      .then((dvdCopy) => {
        console.log(dvdCopy)
        this.dvdCopyForm = new FormGroup({
          code: new FormControl(dvdCopy?.code),
          id: new FormControl(dvdCopy?.id),
          status:new FormControl(dvdCopy?.status),
        });
      });
  }

  deleteOne(code: string) {
    if (confirm('Are you sure you want to delete?') === true) {
      this.dvdCatalogService
        .deleteDvdCopy(code)
        .then((dvdCopy) => this.getAll(this.dvdCatalogId,'', 10, 1));
    }
  }

  onSearch(){
    this.getAll(this.dvdCatalogId,this.search,10,1);
  }
}
