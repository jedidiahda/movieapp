import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Router } from '@angular/router';
//import { AuthenticationService } from '../services/authentication.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private router: Router,
    //private authService: AuthenticationService
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((err) => {
        if (err.status === environment.STATUS_UNAUTHORIZED) {
          //this.authService.authMessage = 'User is unauthorized';
          this.router.navigate(['error']);
        }
        let msg = '';
        if (err.error instanceof ErrorEvent) {
          // client-side error
          msg = err.error.message;
        } else {
          msg = err.error;
        }
        return throwError(() => new Error(msg));
      })
    );
  }
}
