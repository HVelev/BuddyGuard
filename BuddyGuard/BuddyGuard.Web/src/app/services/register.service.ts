import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { LoginDTO } from "../models/login.model";
import { RegisterDTO } from "../models/register.model";

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  private http: HttpClient;
  private controller = 'Register';
  private domain = 'https://localhost:7285/';

  constructor(http: HttpClient) {
    this.http = http;
  }

  public register(formDTO: RegisterDTO): Observable<string> {
    const url = this.buildUrl() + '/Register';

    return this.http.post(url, formDTO, {
      responseType: 'text', headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
} 
