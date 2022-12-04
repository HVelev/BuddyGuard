import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EditBuddyDTO } from '../app/models/edit-buddy.model';

@Injectable({
  providedIn: 'root'
})
export class BuddiesService {
  private domain = 'https://localhost:7285/';
  private controller = 'Buddies';

  constructor(private http: HttpClient) { }

  public upload(data: EditBuddyDTO, file: File): Observable<any> {
    const formData: FormData = new FormData();

    formData.append('file', file);

    formData.append('comment', 'a');

    return this.http.post(`${this.buildUrl()}/Upload`, formData);
  }

  public getImages(): Observable<any> {
    return this.http.get(`${this.buildUrl()}/GetImages`);
  }

  private buildUrl(): string {
    return this.domain + this.controller;
  }
}
