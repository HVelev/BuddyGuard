import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


interface ImageInfo {
  title: string;
  description: string;
  link: string;
}

@Injectable({
  providedIn: 'root'
})

export class ImageService {
  private images: any[] = [];
  private url: string = 'https://api.imgur.com/3/image';
  private clientId: string = '626d467ff2044c4';
  imageLink: any;


  constructor(private http: HttpClient) { }

  async uploadImage(imageFile: File, infoObject: any) {
    let formData = new FormData();
    formData.append('image', imageFile, imageFile.name);
    formData.append('album', 'sMqFwZH6S5deVG6');

    let header = new HttpHeaders({
      "authorization": 'Client-ID ' + this.clientId
    });

    const imageData: any = await this.http.post(this.url, formData, { headers: header }).toPromise();
  }

  async getAlbum() {
    let header = new HttpHeaders({
      "authorization": 'Client-ID ' + this.clientId
    });

    const imageData: any = await this.http.get('https://api.imgur.com/3/album/wrvBdET', { headers: header }).toPromise();
  }

  getImages(): Observable<any> {
    let header = new HttpHeaders({
      "authorization": 'Client-ID ' + this.clientId
    });

    return this.http.get('https://api.imgur.com/3/album/wrvBdET/images', { headers: header });
  }
}
