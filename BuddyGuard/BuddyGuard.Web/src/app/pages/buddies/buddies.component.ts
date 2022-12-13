import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ImageDTO } from '../../models/image.model';
import { ImageService } from '../../services/image.service';

@Component({
  selector: 'app-buddies',
  templateUrl: './buddies.component.html',
  styleUrls: ['./buddies.component.css']
})
export class BuddiesComponent implements OnInit {
  private imageService: ImageService;
  private snackbar: MatSnackBar;

  public imageTitle: string | undefined;
  public imageDescription: string | undefined;
  public imageFile!: File;
  public images: ImageDTO[] = [];
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

  public deleteImage(key: string) {
    this.imageService.deleteImage(key).subscribe({
      next: () => {
        this.getData();
      }
    });
  }

  public getImages() {
    this.imageService.getAlbum();
  }

  private getData() {
    this.imageService.getImages().subscribe({
      next: (value: ImageDTO[]) => {  
        this.images = value;
      }
    });
  }


}
