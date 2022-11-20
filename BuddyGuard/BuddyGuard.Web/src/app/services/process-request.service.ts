import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RequestDTO } from '../models/request.model';

@Injectable({
  providedIn: 'root'
})
export class ProcessRequestService {
  private http: HttpClient;
  private controller = 'ProcessRequest';
  private domain = 'https://localhost:7285/';

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getAllUnreadRequests(): Observable<RequestDTO[]> {
    const url = this.buildUrl() + '/GetAllUnreadRequests';

    return this.http.get<RequestDTO[]>(url, {});
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
}
