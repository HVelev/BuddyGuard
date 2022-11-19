import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormDTO } from '../../../../models/form.model';

@Component({
  selector: 'app-process-request-dialog',
  templateUrl: './process-request-dialog.component.html',
  styleUrls: ['./process-request-dialog.component.css']
})
export class ProcessRequestDialogComponent implements OnInit {
  public form: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<ProcessRequestDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FormDTO,
  ) {
    this.form = new FormGroup({
      nameControl: new FormControl(),
      phoneControl: new FormControl(),
      locationControl: new FormControl(),
      emailControl: new FormControl()
    });
  }
    ngOnInit(): void {
      this.fillForm();
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

  private fillForm() {
    this.form.get('nameControl')?.setValue(this.data.name);
    this.form.get('phoneControl')?.setValue(this.data.phone);
    this.form.get('emailControl')?.setValue(this.data.email);
    this.form.get('locationControl')?.setValue(this.data.location);
  }

}
