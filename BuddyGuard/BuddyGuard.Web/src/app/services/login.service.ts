import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { LoginDTO } from "../models/login.model";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private http: HttpClient;
    private controller = '/Login';
    private area = 'Shared';
  private domain = 'https://localhost:7285/';

  public onUserLogin: Subject<any>;
  public onUserLogout: Subject<void>;

  constructor(http: HttpClient) {
    this.http = http;
    this.onUserLogin = new Subject();
    this.onUserLogout = new Subject();
  }

  public login(user: LoginDTO): Observable<Object> {
    const url = this.buildUrl() + '/Login';

    return this.http.post(url, user, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }

  public isLoggedIn(token: string): Observable<boolean> {
    const url = this.buildUrl() + '/IsLoggedIn';
    const httpParams = new HttpParams().append('token', token);

    return this.http.get<boolean>(url, { params: httpParams });
  }

  public isLoggedInAsUser(token: string): Observable<boolean> {
    const url = this.buildUrl() + '/IsLoggedInAsUser';
    const httpParams = new HttpParams().append('token', token);

    return this.http.get<boolean>(url, { params: httpParams });
  }

  public isLoggedInAsAdmin(token: string): Observable<boolean> {
    const url = this.buildUrl() + '/IsLoggedInAsAdmin';
    const httpParams = new HttpParams().append('token', token);

    return this.http.get<boolean>(url, { params: httpParams });
  }

  public logout(): void {
    sessionStorage.clear();
  }

  private buildUrl(): string {
      return this.domain + this.area + this.controller;
  }
} 
