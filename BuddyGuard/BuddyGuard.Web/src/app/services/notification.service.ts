import { Injectable } from '@angular/core';
import { HttpBackend, HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ImageDTO } from '../models/image.model';
import { InquiryDTO } from '../models/inquiry.model';
import { NotificationDTO } from '../models/notification.model';

@Injectable({
  providedIn: 'root'
})

export class NotificationService {
  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  public getNotifications(): Observable<NotificationDTO[]> {
    return this.http.get<NotificationDTO[]>('https://localhost:7285/Admin/Notification/GetNotifications');
  }
}
