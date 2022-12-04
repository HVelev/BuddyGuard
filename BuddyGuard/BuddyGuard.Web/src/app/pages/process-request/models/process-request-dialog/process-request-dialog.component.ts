import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EditRequestDTO } from '../../../../models/edit-request.model';
import { RequestDTO } from '../../../../models/request.model';
import { RequestService } from '../../../../services/request.service';

@Component({
  selector: 'app-process-request-dialog',
  templateUrl: './process-request-dialog.component.html',
  styleUrls: ['./process-request-dialog.component.css']
})
export class ProcessRequestDialogComponent implements OnInit {
  private service: RequestService;

  public form: FormGroup;
  public animals: FormArray = new FormArray([new FormGroup({
    nameControl: new FormControl(),
    animalTypeControl: new FormControl(),
    speciesControl: new FormControl(),
    animalServiceControl: new FormControl(),
    dogWalkLengthControl: new FormControl(),
    descriptionControl: new FormControl()
  })]);

  constructor(
    public dialogRef: MatDialogRef<ProcessRequestDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: RequestDTO,
    service: RequestService
  ) {
    this.form = new FormGroup({
      nameControl: new FormControl(data.firstName),
      phoneControl: new FormControl(data.phone),
      locationControl: new FormControl(data.location),
      exactLocationControl: new FormControl(data.exactLocation),
      emailControl: new FormControl(data.email),
      startDateControl: new FormControl(data.startDate),
      endDateControl: new FormControl(data.endDate),
      meetingDateControl: new FormControl(data.meetingDate),
      customerServiceControl: new FormControl(data.clientServices),
      commentControl: new FormControl(data.comment),
      priceControl: new FormControl(data.price),
      animalArrayControl: this.animals,
    });

    this.service = service;
  }

  public get FormArrayControls(): FormArray {
    return this.form.get('animalArrayControl') as FormArray;
  }

  ngOnInit(): void {
    this.fillForm();

    this.animals.clear();

    for (let pet of this.data.pets) {
      console.log(pet.services);

      this.animals.push(new FormGroup({
        nameControl: new FormControl(pet.name),
        animalTypeControl: new FormControl(pet.animalType),
        speciesControl: new FormControl(pet.species),
        animalServiceControl: new FormControl(pet.services),
        dogWalkLengthControl: new FormControl(pet.dogWalkLength),
        descriptionControl: new FormControl(pet.petDescription)
      }));
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public isOthersSelected(index: number): boolean | undefined {
    if (!this.FormArrayControls.at(index).get('animalTypeControl')) {
      return undefined;
    }

    if (!this.FormArrayControls.at(index).get('animalTypeControl')!.value) {
      return undefined;
    }

    return true;
  }

  public acceptRequest() {
    this.service.acceptRequest(this.data.id).subscribe({
      next: () => {
        this.dialogRef.close();
      }
    });
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
