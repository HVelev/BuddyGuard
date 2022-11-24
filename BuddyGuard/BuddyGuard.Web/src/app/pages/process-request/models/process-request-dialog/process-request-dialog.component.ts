import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EditRequestDTO } from '../../../../models/edit-request.model';

@Component({
  selector: 'app-process-request-dialog',
  templateUrl: './process-request-dialog.component.html',
  styleUrls: ['./process-request-dialog.component.css']
})
export class ProcessRequestDialogComponent implements OnInit {
  public form: FormGroup;
  public animals: FormArray = new FormArray([new FormGroup({
    nameControl: new FormControl(undefined, Validators.required),
    animalTypeControl: new FormControl(undefined, Validators.required),
    speciesControl: new FormControl(),
    animalServiceControl: new FormControl(),
    dogWalkLengthControl: new FormControl(),
    descriptionControl: new FormControl()
  })]);

  constructor(
    public dialogRef: MatDialogRef<ProcessRequestDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: EditRequestDTO,
  ) {
    this.form = new FormGroup({
      nameControl: new FormControl(),
      phoneControl: new FormControl(),
      locationControl: new FormControl(),
      emailControl: new FormControl(),
      animalArrayControl: this.animals,
      dateLocationGroupControl: new FormGroup({
        startDateControl: new FormControl(new Date(2022, 12, 12), Validators.required),
        endDateControl: new FormControl(new Date(2022, 12, 12), Validators.required),
        meetingDateControl: new FormControl(),
        locationControl: new FormControl(undefined, Validators.required)
      }),
      customerServiceControl: new FormControl(),
      commentControl: new FormControl()
    });
  }

  public get FormArrayControls(): FormArray {
    return this.form.get('animalArrayControl') as FormArray;
  }

    ngOnInit(): void {
      this.fillForm();
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public isOthersSelected(index: number): boolean | undefined {
    debugger;
    if (!this.FormArrayControls.at(index).get('animalTypeControl')) {
      return undefined;
    }

    if (!this.FormArrayControls.at(index).get('animalTypeControl')!.value) {
      return undefined;
    }

    return true;
  }

  public close() {
    this.dialogRef.close();
  }

  private fillForm() {
    //this.form.get('nameControl')?.setValue(this.data.name);
    //this.form.get('phoneControl')?.setValue(this.data.phone);
    //this.form.get('emailControl')?.setValue(this.data.email);
    //this.form.get('locationControl')?.setValue(this.data.location);
  }

}
