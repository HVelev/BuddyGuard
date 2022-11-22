import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EditRequestDTO } from '../models/edit-request.model';

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

  public getAllUnreadRequests(): Observable<EditRequestDTO[]> {
    const url = this.buildUrl() + '/GetAllUnreadRequests';

    return this.http.get<EditRequestDTO[]>(url, {});
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
}
