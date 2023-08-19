import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Credentials } from '../models/credentials.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  basedUrl: string = environment.basedUrl;
  jwtDecode:any;
  #authError!: string;

  constructor(private http: HttpClient, private jwtService: JwtHelperService) {
    this.jwtDecode = this.jwtService.decodeToken(this.getToken());
  }

  register(user: Credentials): Promise<Credentials | undefined> {
    user.role = 'user';
    return this.http
      .post<Credentials>(`${this.basedUrl}/Account`, user)
      .toPromise();
  }

  login(user: Credentials): Promise<any> {
    return this.http
      .post<any>(`${this.basedUrl}/Account/login`, user)
      .toPromise();
  }

  logout() {
    localStorage.removeItem(environment.userTokenName);
  }

  setToken(token: any) {
    localStorage.setItem(environment.userTokenName, token);
  }

  getToken(): any {
    return localStorage.getItem(environment.userTokenName);
  }

  get name(): string {
    return this.jwtDecode ? this.jwtDecode.Name : '';
  }

  get customerId(): string {
    let jwtDecode = this.jwtService.decodeToken(this.getToken());
    return jwtDecode ? jwtDecode.CustomerId : '';
  }

  public get userRole(): string {
    return this.jwtDecode ? this.jwtDecode.Role : '';
  }

  get isLoggedIn(): boolean {
    let token = this.getToken();
    return token == null || token == '' ? false : true;
  }

  get authMessage(): string {
    return this.#authError;
  }

  set authMessage(err: string) {
    this.#authError = err;
  }
}
