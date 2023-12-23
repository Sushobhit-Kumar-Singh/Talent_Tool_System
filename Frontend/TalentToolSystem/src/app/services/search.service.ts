import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  constructor(private http: HttpClient) { }
  gateWayBaseUrl = `https://localhost:7071/api/search`;

  searchCandidates(queryParams: any): Observable<any[]> {
    const apiUrl = `${this.gateWayBaseUrl}/SearchCandidates`;
    const params = new HttpParams({ fromObject: queryParams });
    return this.http.get<any[]>(apiUrl, { params });
  }

  searchDemands(queryParams: any): Observable<any[]> {
    const apiUrl = `${this.gateWayBaseUrl}/SearchDemands`;
    const params = new HttpParams({ fromObject: queryParams });
    return this.http.get<any[]>(apiUrl, { params });
  }
}
