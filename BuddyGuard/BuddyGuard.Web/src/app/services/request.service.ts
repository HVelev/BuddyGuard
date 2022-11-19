import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { FormDTO } from "../models/form.model";
import { UserDTO } from "../models/user.model";
import { NomenclatureDTO } from "../shared/models/nomenclature-dto";

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  private http: HttpClient;
  private controller = 'Request';
  private domain = 'https://localhost:7285/';

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getAnimalTypes(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetAnimalTypes';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getLocations(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetLocations';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getClientServices(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetClientServices';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getSmallDogServices(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetSmallDogServices';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getBigDogServices(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetBigDogServices';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getCatServices(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetCatServices';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
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
