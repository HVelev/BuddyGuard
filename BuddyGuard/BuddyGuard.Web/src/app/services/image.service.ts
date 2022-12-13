import { Injectable } from '@angular/core';
import { HttpBackend, HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ImageDTO } from '../models/image.model';

interface ImageInfo {
  title: string;
  description: string;
  link: string;
}

@Injectable({
  providedIn: 'root'
})

export class ImageService {
  private url: string = 'https://api.imgur.com/3/image';
  private clientId: string = '626d467ff2044c4';
  imageLink: any;
  private http: HttpClient;

  constructor(handler: HttpBackend) {
    this.http = new HttpClient(handler);
  }

  uploadImage(imageFile: File, infoObject: any) {
    let formData = new FormData();

    formData.append('image', imageFile, imageFile.name);
    formData.append('description', 'test');

    return this.http.post('https://localhost:7285/Shared/Image/AddImage', formData);
  }

  async getAlbum() {
    let header = new HttpHeaders({
      "UserName": 'buddyguard'
    });

    const imageData: any = await this.http.get('https://iam.amazonaws.com/?Action=CreateAccessKey', { headers: header }).toPromise();
    //deleteHash = F5ykCrv8SBh1asi
    //id = uqhPX10
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
