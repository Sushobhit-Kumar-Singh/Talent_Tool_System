import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  /*************************************************************************
   Base URLs
  **************************************************************************/
  // logBaseUrl = 'https://localhost:7046/api/Logs/';
  // candidateBaseUrl = 'https://localhost:7095/api/Candidate/';
  // demandBaseUrl = "https://localhost:7296/api/Demand/";
  gateWayBaseUrl = `https://localhost:7071/api/`;

  //constructor
  constructor(private http: HttpClient) {}

  /*************************************************************************
   Logs Operations
  **************************************************************************/

  GetAllCandidateLogs() {
    let url = this.gateWayBaseUrl + 'Logs/GetAllCandidateLogs';
    let data = this.http.get<any[]>(url);
    return data;
  }

  GetAllDemandLogs() {
    let url = this.gateWayBaseUrl + 'Logs/GetAllDemandLogs';
    let data = this.http.get<any[]>(url);
    return data;
  }

  /*************************************************************************
   Candidate Operations
  **************************************************************************/
  GetAllCandidate() {
    let url = `${this.gateWayBaseUrl}Candidate/getcandidatelist`;
    return this.http.get<any[]>(url);
  }
  DeleteCandidate(candidate: any) {
    let url = `${this.gateWayBaseUrl}Candidate/deletecandidate?CandidateId=${candidate.candidateId}`;
    return this.http.delete<any>(url, candidate);
  }
  CreateCandidate(candidate: any) {
    let url = `${this.gateWayBaseUrl}Candidate/addcandidate`;
    return this.http.post(url, candidate, { responseType: 'text' });
  }
  UpdateCandidate(candidate: any) {
    //let url = "https://localhost:7071/api/Candidate/updatecandidate";
    let url = `${this.gateWayBaseUrl}Candidate/updatecandidate`;
    return this.http.put(url, candidate, { responseType: 'text' });
  }

  /*************************************************************************
   Demand Operations
  **************************************************************************/
  GetAllDemand() {
    let url = `${this.gateWayBaseUrl}Demand/getdemandlist`;
    return this.http.get<any[]>(url);
  }
  DeleteDemand(demand: any) {
    let url = `${this.gateWayBaseUrl}Demand/deletedemand?demandId=${demand.demandId}`;
    return this.http.delete<any>(url);
  }
  CreateDemand(demand: any) {
    let url = `${this.gateWayBaseUrl}Demand/adddemand`;
    return this.http.post<any>(url, demand, { responseType: 'json' });
  }
  UpdateDemand(demand: any) {
    let url = `${this.gateWayBaseUrl}Demand/updatedemand`;
    return this.http.put(url, demand, { responseType: 'text' });
  }
}
