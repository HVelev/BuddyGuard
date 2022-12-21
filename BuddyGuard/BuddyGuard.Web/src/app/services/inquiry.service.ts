import { Injectable } from '@angular/core';
import { HttpBackend, HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ImageDTO } from '../models/image.model';
import { InquiryDTO } from '../models/inquiry.model';

@Injectable({
  providedIn: 'root'
})

export class InquiryService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  public sendInquiry(model: InquiryDTO): Observable<void> {
    return this.http.post<void>('https://localhost:7285/Shared/Inquiry/SendInquiry', model);
  }
}
