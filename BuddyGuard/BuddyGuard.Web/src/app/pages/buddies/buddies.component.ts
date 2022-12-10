import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
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
  private snackbar: MatSnackBar;

  public imageTitle: string | undefined;
  public imageDescription: string | undefined;
  public imageFile!: File;
  public images: any[] = [];
  public role: string | undefined | null;
  public form: FormGroup;

  constructor
    (
      imageService: ImageService,
      snackbar: MatSnackBar
    ) {
    this.imageService = imageService;
    this.snackbar = snackbar;
    this.form = new FormGroup({
      descriptionControl: new FormControl(),
      imageControl: new FormControl(undefined, Validators.required)
    });
  }

  ngOnInit() {
    this.getData();
    this.role = sessionStorage.getItem('role');
  }

  imageInputChange(imageInput: any) {
    this.imageFile = imageInput.files[0];
  }

  addImage() {
    this.form.get('imageControl')!.markAsDirty();
    this.form.get('imageControl')!.markAsTouched();

    if (this.form.valid) {
      let infoObject = {
        title: this.imageTitle,
        description: this.imageDescription
      }

      this.imageService.uploadImage(this.imageFile, infoObject).subscribe({
        next: () => {
          this.snackbar.open('Успешно качена снимка', 'Затвори', {
            duration: 4000
          });

          this.form.get('imageControl')!.reset();
          this.imageTitle = "";
          this.imageDescription = "";

          this.getData();
        },
        error: () => {
          this.snackbar.open('Възникна проблем при качването на снимката Ви', 'Затвори', {
            duration: 4000,
            panelClass: 'red-snackbar'
          });
        }
      });

    }
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

  public deleteImage(id: string) {
    this.imageService.deleteImage(id).subscribe();
  }
}
