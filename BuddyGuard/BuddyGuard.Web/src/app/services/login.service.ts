import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FormDTO } from "../models/form.model";
import { LoginDTO } from "../models/login.model";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private http: HttpClient;
  private controller = 'Login';
  private domain = 'https://localhost:7285/';

  constructor(http: HttpClient) {
    this.http = http;
  }

  public login(user: LoginDTO): Observable<Object> {
    const url = this.buildUrl() + '/Login';

    return this.http.post(url, user, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
} 