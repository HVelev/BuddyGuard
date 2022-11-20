import { DatePipe } from "@angular/common";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PetDTO } from "../models/pet.model";
import { RequestDTO } from "../models/request.model";
import { UserDTO } from "../models/user.model";
import { NomenclatureDTO } from "../shared/models/nomenclature-dto";

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  private http: HttpClient;
  private controller = 'Request';
  private domain = 'https://localhost:7285/';
  private datePipe: DatePipe;

  constructor(http: HttpClient,
    datePipe: DatePipe
  ) {
    this.http = http;
    this.datePipe = datePipe;
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

  public submitForm(data: RequestDTO): Observable<void> {
    const url = this.buildUrl() + '/SubmitForm';
    
   
    return this.http.post<void>(url, data);
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
} 
