import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { EditRequestDTO } from '../models/edit-request.model';
import { RequestDTO } from '../models/request.model';

@Injectable({
  providedIn: 'root'
})
export class ProcessRequestService {
  private readonly http: HttpClient;
  private readonly controller = '/ProcessRequest';
  private readonly area = 'Admin';
  private readonly domain = 'https://localhost:7285/';

  public readonly onRequestDialogClosed: Subject<void>;

  constructor(http: HttpClient) {
    this.http = http;
    this.onRequestDialogClosed = new Subject();
  }

  public getAllRequests(): Observable<RequestDTO[]> {
    const url = this.buildUrl() + '/GetAllRequests';

    return this.http.get<RequestDTO[]>(url);
  }

  public getAllUnreadRequests(): Observable<RequestDTO[]> {
    const url = this.buildUrl() + '/GetAllUnreadRequests';

    return this.http.get<RequestDTO[]>(url);
  }

  public getAllAcceptedRequests(): Observable<RequestDTO[]> {
    const url = this.buildUrl() + '/GetAllAcceptedRequests';

    return this.http.get<RequestDTO[]>(url);
  }

  public getRequest(requestId: number): Observable<RequestDTO> {
    const url = this.buildUrl() + '/GetRequest';
    const httpParams = new HttpParams().append('requestId', requestId);
    debugger;
    return this.http.get<RequestDTO>(url, {
      params: httpParams
    });
  }

  public markRequestAsRead(id: number): Observable<void> {
    const url = this.buildUrl() + '/MarkRequestAsRead';

    const httpParams = new HttpParams().append('id', id);

    return this.http.put<void>(url, {}, {
      params: httpParams
    });
  }
  
  public acceptRequest(id: number): Observable<void> {
    const url = this.buildUrl() + '/AcceptRequest';

    const httpParams = new HttpParams().append('id', id);

    return this.http.put<void>(url, {}, {
      params: httpParams
    });
  }

  public rejectRequest(id: number): Observable<void> {
    const url = this.buildUrl() + '/RejectRequest';

    const httpParams = new HttpParams().append('id', id);

    return this.http.delete<void>(url, {
      params: httpParams
    });
  }

  public deleteRequest(id: number): Observable<void> {
    const httpParams = new HttpParams().append('id', id);

    return this.http.delete<void>(`${this.buildUrl()}/DeleteRequest`, {
      params: httpParams
    });
  }

  private buildUrl(): string {
    return this.domain + this.area + this.controller;
  }
}
