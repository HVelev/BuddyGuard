import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ImageDTO } from '../../models/image.model';
import { ImageService } from '../../services/image.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';
import { ImageDialogComponent } from './image-dialog/image-dialog.component';

@Component({
  selector: 'app-buddies',
  templateUrl: './buddies.component.html',
  styleUrls: ['./buddies.component.css']
})
export class BuddiesComponent implements OnInit {
  private imageService: ImageService;
  private snackbar: MatSnackBar;

  public imageFile!: File;
  public images: ImageDTO[] = [];
  public role: string | undefined | null;
  public form: FormGroup;
  public dialog: MatDialog;
  public imgDialog: MatDialog;

  public constructor
    (
      imageService: ImageService,
      snackbar: MatSnackBar,
      dialog: MatDialog,
      imgDialog: MatDialog
    ) {
    this.imageService = imageService;
    this.snackbar = snackbar;
    this.dialog = dialog;
    this.imgDialog = imgDialog;

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

    if (this.imageFile.size >= 10485760) {
      this.snackbar.open('Максималният размер за качване на снимка е 10MB', 'Затвори', {
        duration: 4000,
        panelClass: 'red-snackbar'
      });

      this.form.get('imageControl')!.reset();
      this.form.get('descriptionControl')!.reset();

      return;
    }

    if (this.form.valid) {
      const description = this.form.get('descriptionControl')!.value;

      this.imageService.uploadImage(this.imageFile, description).subscribe({
        next: () => {
          this.snackbar.open('Успешно качена снимка', 'Затвори', {
            duration: 4000
          });

          this.form.get('imageControl')!.reset();
          this.form.get('descriptionControl')!.reset();

          this.getData();
        },
        error: (err: any) => {
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

  public openImage(value: ImageDTO) {
    debugger;
    const dialogRef = this.imgDialog.open(ImageDialogComponent, {
      height: '100%',
      maxWidth: '100%',
      data: value
    });
    dialogRef.afterClosed().subscribe();
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

  private getData() {
    this.imageService.getImages().subscribe({
      next: (value: ImageDTO[]) => {  
        this.images = value;
      }
    });
  }


}
