import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FormDTO } from "../models/form.model";

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  private http: HttpClient;
  private area = 'Request';
  private controller = 'Request';
  private domain = 'https://localhost:7285/';

  constructor(http: HttpClient) {
    this.http = http;
  }

  public submitForm(data: FormDTO): Observable<string> {
    const url = this.buildUrl() + '/SubmitForm';

    return this.http.post(url, data, {
      responseType: 'text', headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
} 
