import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { RequestedDVD } from 'src/app/models/requested-dvd.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { RequestDVDService } from 'src/app/services/request-dvd.service';

@Component({
  selector: 'app-request-dvd',
  templateUrl: './request-dvd.component.html',
  styleUrls: ['./request-dvd.component.css'],
})
export class RequestDVDComponent implements OnInit {
  requests: RequestedDVD[] = [];
  requestDVDForm!: FormGroup;
  constructor(
    private requestDvDService: RequestDVDService,
    private authService: AuthenticationService
  ) {}
  ngOnInit(): void {
    this.getAll();

    this.requestDVDForm = new FormGroup({
      title: new FormControl(''),
      submissionDate: new FormControl(new Date()),
      customerId: new FormControl(this.authService.customerId)
    });
  }

  getAll() {
    this.requestDvDService
      .getAll(this.authService.customerId)
      .then((result) => result && (this.requests = result))
      .catch((err) => console.log(err));
  }

  onSubmit() {
    this.requestDvDService
      .createOne(this.requestDVDForm.value)
      .then((result) => this.getAll())
      .catch((err) => console.log(err));
  }
}
