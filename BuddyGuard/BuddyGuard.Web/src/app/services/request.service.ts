import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { EditRequestDTO } from "../models/edit-request.model";
import { RequestDTO } from "../models/request.model";
import { NomenclatureDTO } from "../shared/models/nomenclature-dto";

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  private http: HttpClient;
  private controller = '/Request';
  private area = 'User';
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

  public getSmallDogWalkLengths(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetSmallDogWalkLengths';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getBigDogServices(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetBigDogServices';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getBigDogWalkLengths(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetBigDogWalkLengths';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public getCatServices(): Observable<NomenclatureDTO<number>[]> {
    const url = this.buildUrl() + '/GetCatServices';

    return this.http.get<NomenclatureDTO<number>[]>(url, {});
  }

  public submitForm(data: EditRequestDTO): Observable<void> {
    const url = this.buildUrl() + '/SubmitForm';
    
   
    return this.http.post<void>(url, data);
  }

  private buildUrl(): string {
    return this.domain + this.area + this.controller;
  }
} 
