import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormDTO } from '../../../../models/form.model';

@Component({
  selector: 'app-process-request-dialog',
  templateUrl: './process-request-dialog.component.html',
  styleUrls: ['./process-request-dialog.component.css']
})
export class ProcessRequestDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<ProcessRequestDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FormDTO,
  ) {
    debugger;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
