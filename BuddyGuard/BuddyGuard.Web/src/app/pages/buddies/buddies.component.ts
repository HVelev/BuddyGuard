import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ImageDTO } from '../../models/image.model';
import { ImageService } from '../../services/image.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

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
  public dialog: MatDialog;

  public constructor
    (
      imageService: ImageService,
      snackbar: MatSnackBar,
      dialog: MatDialog
    ) {
    this.imageService = imageService;
    this.snackbar = snackbar;
    this.dialog = dialog;

    this.form = new FormGroup({
      descriptionControl: new FormControl(),
      imageControl: new FormControl(undefined, Validators.required)
    });
  }

  public ngOnInit() {
    this.getData();
    this.role = sessionStorage.getItem('role');
  }

  public imageInputChange(imageInput: any) {
    this.imageFile = imageInput.files[0];
  }

  public openDialog(key: string): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Изтриване на снимка', message: 'Сигурни ли сте, че желаете да изтриете тази снимка?' },
      height: '200px',
      width: '600px'
    });

    dialogRef.afterClosed().subscribe({
      next: (result: any) => {
        if (result) {
          this.deleteImage(key);
        }
      }
    });
  }

  public addImage() {
    this.form.get('imageControl')!.markAsDirty();
    this.form.get('imageControl')!.markAsTouched();

    console.log(this.imageFile.type);

    if (this.imageFile.size >= 10485760) {
      this.snackbar.open('Максималният размер за качване на снимка е 10MB', 'Затвори', {
        duration: 4000,
        panelClass: 'red-snackbar'
      });

      this.form.get('imageControl')!.reset();
      this.imageTitle = "";
      this.imageDescription = "";


      return;
    }

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
        error: (err: any) => {
          debugger;
          if (err.status === 422) {
            this.snackbar.open('Файлът, който се опитвате да качите, има невалиден формат', 'Затвори', {
              duration: 4000,
              panelClass: 'red-snackbar'
            });
          } else {
            this.snackbar.open('Възникна проблем при качването на снимката Ви', 'Затвори', {
              duration: 4000,
              panelClass: 'red-snackbar'
            });
          }
        }
      });

    }
  }

  public deleteImage(key: string) {
    this.imageService.deleteImage(key).subscribe({
      next: () => {
        this.snackbar.open('Успешно изтрита снимка', 'Затвори', {
          duration: 4000
        });
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
