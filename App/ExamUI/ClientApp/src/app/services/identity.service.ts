import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Login } from '../models/login';
import { environment, IdentityCompanyPublic } from '../../environments/environment';
import { UserData } from '../models/user-data';


@Injectable({
  providedIn: 'root'
})
export class IdentityService {

  constructor(private http: HttpClient) { }

  authanticateUser(credentials: Login): Observable<string> {
    const url = environment.gatewayBaseUrl + environment.authenticateUrl;
    return this.http.post<string>(url, credentials);
  }

  createUser(user: UserData): Observable<string> {
    const url = environment.gatewayBaseUrl + environment.createUserUrl;
    return this.http.post<string>(url, user);
  }

  // identityCompanyPublic(credentials: Login): Observable<string> {
  //   const url = IdentityCompanyPublic.gatewayBaseUrl + IdentityCompanyPublic.Url;
  //   return this.http.post<string>(url, credentials);
  // }
}
