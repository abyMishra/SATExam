import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor(private http: HttpClient) { }

  getAllCountries(): Observable<any> {
    const url = environment.gatewayBaseUrl + environment.contentCountriesUrl;
    return this.http.get(url);
  }

  getAllCurrencies(): Observable<any> {
    const url = environment.gatewayBaseUrl + environment.contentCurrenciesUrl;
    return this.http.get(url);
  }

  
}
