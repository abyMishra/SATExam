import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { DestinationMasterData, TaxDetail } from '../models/destination-master-model';


@Injectable({
  providedIn: 'root'
})
export class DestinationMasterService {

  constructor(private http: HttpClient) { }

  addDestinationMasterGeneralInformation(destinationMasterData: DestinationMasterData): Observable<string> {
    const url = environment.gatewayBaseUrl; // + environment.addDestinationMasterUrl;
    return this.http.post<string>(url, destinationMasterData);
  }

  updateGeneralInformation(destinationMasterData: DestinationMasterData): Observable<string> {
    const url = environment.gatewayBaseUrl; // + environment.updateGeneralInformationUrl;
    return this.http.post<string>(url, destinationMasterData);
  }

  getAllDestinations() : Observable<DestinationMasterData[]> {
    const url = environment.gatewayBaseUrl; // + environment.GetAllDestinationsUrl;
    return this.http.get<DestinationMasterData[]>(url);
  }

  deleteDestination(objectId: string) : Observable<boolean> {
    const url = environment.gatewayBaseUrl;//  + environment.DeleteDestinationUrl;
    return this.http.delete<boolean>(url + '?objectId=' + objectId);
  }

  deleteDestinationTaxInfo(objectId: string, taxInfo: TaxDetail) : Observable<boolean> {
    const url = environment.gatewayBaseUrl; // + environment.DeleteDestinationTaxInfoUrl;
    return this.http.post<boolean>(url + '?objectId=' + objectId, taxInfo);
  }
}
