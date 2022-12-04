import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BuddiesService } from '../../../services/buddies.service';
import { EditBuddyDTO } from '../../models/edit-buddy.model';
import { ImageService } from '../../services/image.service';

@Component({
  selector: 'app-buddies',
  templateUrl: './buddies.component.html',
  styleUrls: ['./buddies.component.css']
})
export class BuddiesComponent implements OnInit {
  //selectedFiles?: FileList;
  //selectedFileNames: string[] = [];

  //progressInfos: any[] = [];
  //message: string[] = [];

  //previews: string[] = [];
  //imageInfos?: Observable<any>;
  //public images: string[] = [];

  //constructor(private service: BuddiesService) { }

  //ngOnInit(): void {
  //  this.service.getImages().subscribe({
  //    next: (value: any) => {
  //      this.images.push(value[0].image);
  //    }
  //  });
  //}

  //selectFiles(event: any): void {
  //  this.message = [];
  //  this.progressInfos = [];
  //  this.selectedFileNames = [];
  //  this.selectedFiles = event.target.files;

  //  this.previews = [];
  //  if (this.selectedFiles && this.selectedFiles[0]) {
  //    const numberOfFiles = this.selectedFiles.length;
  //    for (let i = 0; i < numberOfFiles; i++) {
  //      const reader = new FileReader();

  //      reader.onload = (e: any) => {
  //        console.log(e.target.result);
  //        this.previews.push(e.target.result);
  //      };

  //      reader.readAsDataURL(this.selectedFiles[i]);

  //      this.selectedFileNames.push(this.selectedFiles[i].name);
  //    }
  //  }
  //}

  //upload(idx: number, file: File): void {
  //  this.progressInfos[idx] = { value: 0, fileName: file.name };

  //  if (file) {
  //    const data = new EditBuddyDTO({
  //      userId: 'asdf',
  //      comment: '?'
  //    });

  //    this.service.upload(data, file).subscribe(
  //      () => {
  //        if (true) {
  //          const msg = 'Uploaded the file successfully: ' + file.name;
  //          this.message.push(msg);
  //        }
  //      },
  //      (err: any) => {
  //        this.progressInfos[idx].value = 0;
  //        const msg = 'Could not upload the file: ' + file.name;
  //        this.message.push(msg);
  //      }
  //    );
  //  }
  //}

  //uploadFiles(): void {
  //  this.message = [];

  //  if (this.selectedFiles) {
  //    for (let i = 0; i < this.selectedFiles.length; i++) {
  //      this.upload(i, this.selectedFiles[i]);
  //    }
  //  }
  //}
  private imageService: ImageService;

  public imageTitle: string | undefined;
  public imageDescription: string | undefined;
  public imageFile!: File;
  public images: any[] = [];
  public role: string | undefined | null;

  constructor(imageService: ImageService) {
    this.imageService = imageService;
  }

  ngOnInit() {
    this.getData();
    this.role = sessionStorage.getItem('role');
  }

  imageInputChange(imageInput: any) {
    this.imageFile = imageInput.files[0];
  }

  addImage() {
    let infoObject = {
      title: this.imageTitle,
      description: this.imageDescription
    }
    this.imageService.uploadImage(this.imageFile, infoObject);
    this.imageTitle = "";
    this.imageDescription = "";

    this.getData();
  }

  private getData() {
    this.imageService.getImages().subscribe({
      next: (value: any) => {
        this.images = value.data;
      }
    });
  }

  getImages() {
    this.imageService.getAlbum();
  }
}
