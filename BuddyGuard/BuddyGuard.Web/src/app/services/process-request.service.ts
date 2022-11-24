import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FormDTO } from '../models/form.model';

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

  public getAllUnreadRequests(): Observable<FormDTO[]> {
    const url = this.buildUrl() + '/GetAllUnreadRequests';

    return this.http.get<FormDTO[]>(url, {});
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
}
