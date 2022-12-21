import { Injectable } from '@angular/core';
import { HttpBackend, HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ImageDTO } from '../models/image.model';

@Injectable({
  providedIn: 'root'
})

export class ImageService {
  private http: HttpClient;

  constructor(handler: HttpBackend) {
    this.http = new HttpClient(handler);
  }

  uploadImage(imageFile: File, description: string | undefined) {
    let formData = new FormData();

    formData.append('image', imageFile, imageFile.name);
    if (description) {
      formData.append('description', description);
    }

    return this.http.post('https://localhost:7285/Shared/Image/AddImage', formData);
  }

  getImages(): Observable<ImageDTO[]> {

    return this.http.get<ImageDTO[]>('https://localhost:7285/Shared/Image/GetImages');
  }

  public deleteImage(key: string): Observable<void> {
    const httpParams = new HttpParams().append('key', key);

    return this.http.delete<void>(`https://localhost:7285/Shared/Image/DeleteImage`, {
      params: httpParams
    });
  }
}
