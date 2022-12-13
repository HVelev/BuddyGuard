import { DatePipe } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RequestDTO } from '../../../../models/request.model';
import { ProcessRequestService } from '../../../../services/process-request.service';

@Component({
  selector: 'app-process-request-dialog',
  templateUrl: './process-request-dialog.component.html',
  styleUrls: ['./process-request-dialog.component.css']
})
export class ProcessRequestDialogComponent implements OnInit {
  private service: ProcessRequestService;
  private datePipe: DatePipe;

  public form: FormGroup;
  public animals: FormArray = new FormArray([new FormGroup({
    nameControl: new FormControl(),
    animalTypeControl: new FormControl(),
    speciesControl: new FormControl(),
    animalServiceControl: new FormControl(),
    dogWalkLengthControl: new FormControl(),
    descriptionControl: new FormControl()
  })]);

  public constructor(
    public dialogRef: MatDialogRef<ProcessRequestDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: RequestDTO,
    service: ProcessRequestService,
    datePipe: DatePipe
  ) {
    this.datePipe = datePipe;

    this.form = new FormGroup({
      nameControl: new FormControl(data.firstName),
      phoneControl: new FormControl(data.phone),
      locationControl: new FormControl(data.location),
      addressControl: new FormControl(data.address),
      emailControl: new FormControl(data.email),
      startDateControl: new FormControl(this.datePipe.transform(data.startDate, 'dd/MM/YYYY')),
      endDateControl: new FormControl(this.datePipe.transform(data.endDate, 'dd/MM/YYYY')),
      meetingDateControl: new FormControl(data.meetingDate ?? 'Неуточнено'),
      customerServiceControl: new FormControl(data.clientServices),
      commentControl: new FormControl(data.comment),
      priceControl: new FormControl(data.price),
      animalArrayControl: this.animals,
    });

    this.service = service;
  }

  public get formArrayControls(): FormArray {
    return this.form.get('animalArrayControl') as FormArray;
  }

  public ngOnInit(): void {
    this.animals.clear();

    for (let pet of this.data.pets) {
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

  public isOthersSelected(index: number): boolean | undefined {
    if (!this.formArrayControls.at(index).get('animalTypeControl') || !this.formArrayControls.at(index).get('animalTypeControl')!.value) {
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

  public rejectRequest() {
    this.service.rejectRequest(this.data.id).subscribe({
      next: () => {
        this.dialogRef.close();
      }
    });
  }

  public close() {
    this.dialogRef.close();
  }
}
