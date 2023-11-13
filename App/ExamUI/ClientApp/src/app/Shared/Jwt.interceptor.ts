import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

  // add auth header with jwt if account is logged in and request is to the api url
  const token = localStorage.getItem('token');
  const isLoggedIn = token != undefined ? true : false;
  const isLoginUrl = request.url.indexOf(environment.authenticateUrl) > 0;
  if (isLoggedIn && !isLoginUrl) {
      request = request.clone({
          setHeaders: { Authorization: `Bearer ${token}` }
      });
  }


    return next.handle(request);
  }
}
