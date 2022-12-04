import { AfterContentInit, AfterViewInit, Component, ContentChild, OnChanges, OnInit, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatSelect, MatSelectChange } from '@angular/material/select';
import { MatStep, MatStepper } from '@angular/material/stepper';
import { forEach } from 'lodash';
import { Moment } from 'moment';
import { EditPetDTO } from '../../models/edit-pet.model';
import { EditRequestDTO } from '../../models/edit-request.model';
import { RequestService } from '../../services/request.service';
import { NomenclatureDTO } from '../../shared/models/nomenclature-dto';

export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  },
};

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css'],
  providers: [
    { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }
  ]
})
export class RequestComponent implements OnInit, AfterContentInit, AfterViewInit {
  private service: RequestService;

  @ViewChild('animalType')
  public animalTypeMatSelect!: MatSelect;
  @ViewChild('stepper')
  public stepper!: MatStepper;

  public form: FormGroup;
  public animalTypes: NomenclatureDTO<number>[] = [];
  public locations: NomenclatureDTO<number>[] = [];
  public clientServices: NomenclatureDTO<number>[] = [];
  public smallDogServices: NomenclatureDTO<number>[] = [];
  public smallDogWalkLengths: NomenclatureDTO<number>[] = [];
  public bigDogServices: NomenclatureDTO<number>[] = [];
  public bigDogWalkLengths: NomenclatureDTO<number>[] = [];
  public catServices: NomenclatureDTO<number>[] = [];
  public animalServices: NomenclatureDTO<number>[][] = [];
  public petWalkLengths: NomenclatureDTO<number>[][] = [];
  public isVisible: boolean[] = [false];
  public currentlySelectedPet: string | undefined;
  public finalPrice: number = 0;
  public minStartDate: Date | undefined;
  public maxEndDate: Date | undefined;
  public animals: FormArray = new FormArray([new FormGroup({
    nameControl: new FormControl('asd', [Validators.required, Validators.maxLength(100)]),
    animalTypeControl: new FormControl(undefined, Validators.required),
    speciesControl: new FormControl(),
    animalServiceControl: new FormControl(),
    dogWalkLengthControl: new FormControl(),
    descriptionControl: new FormControl()
  })]);

  public get FormArrayControls(): FormArray {
    return this.form.get('animalArrayControl') as FormArray;
  }

  public get dateLocationGroup(): FormGroup {
    return this.form.get('dateLocationGroupControl') as FormGroup;
  }

  constructor(service: RequestService,
    private dateAdapter: DateAdapter<Date>
  ) {
    this.service = service;

    this.dateAdapter.setLocale('bg-BG');

    this.service.getAnimalTypes().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.animalTypes = value;
      }
    });

    this.service.getLocations().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.locations = value;
      }
    });

    this.service.getClientServices().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.clientServices = value;
      }
    });

    this.service.getSmallDogServices().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.smallDogServices = value;
      }
    });

    this.service.getSmallDogWalkLengths().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.smallDogWalkLengths = value;
      }
    });

    this.service.getBigDogServices().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.bigDogServices = value;
      }
    });

    this.service.getBigDogWalkLengths().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.bigDogWalkLengths = value;
      }
    });

    this.service.getCatServices().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.catServices = value;
      }
    });

    this.form = new FormGroup({
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

  ngOnInit(): void {
    this.dateLocationGroup.get('startDateControl')!.valueChanges.subscribe({
      next: (value: any) => {
        this.maxEndDate = value._d;
      }
    });

    this.dateLocationGroup.get('endDateControl')!.valueChanges.subscribe({
      next: (value: any) => {
        this.minStartDate = value._d;
      }
    });

    this.form.get('customerServiceControl')!.valueChanges.subscribe({
      next: () => {
        this.calculate();
      }
    });
  }

  ngAfterContentInit(): void {
    this.form.get('customerServiceControl')!.valueChanges.subscribe({
      next: (value: any) => {
        debugger;
      }
    });
  }

  ngAfterViewInit(): void {
    this.stepper.selectionChange.subscribe({
      next: (value: any) => {
        if (value.selectedIndex === 2) {
          this.calculate();
        }
      }
    });
  }

  public getDays(startDate: Date, endDate: Date): number {
    const msInDay = 24 * 60 * 60 * 1000;

    return Math.round(Math.abs(Number(endDate) - Number(startDate)) / msInDay) + 1;
  }

  public calculate() {
    this.finalPrice = 0;

    for (let control of this.FormArrayControls.controls) {
      if (control.get('dogWalkLengthControl')!.value) {
        this.finalPrice += control.get('dogWalkLengthControl')!.value.price;
      }

      if (control.get('animalServiceControl')!.value) {
        for (let service of control.get('animalServiceControl')!.value) {
          this.finalPrice += service.price;
        }
      }
    }

    this.finalPrice += this.getDays(this.form.get('dateLocationGroupControl')!.get('startDateControl')!.value, this.form.get('dateLocationGroupControl')!.get('endDateControl')!.value) * 9.99 * this.FormArrayControls.length;

    this.finalPrice += this.form.get('dateLocationGroupControl')!.get('locationControl')!.value.price;

    if (this.form.get('customerServiceControl')!.value) {
      for (let service of this.form.get('customerServiceControl')!.value) {
        this.finalPrice += service.price;
      }
    }
  }

  public addAnimal() {
    const group = new FormGroup({
      nameControl: new FormControl(undefined, Validators.required),
      animalTypeControl: new FormControl(undefined, Validators.required),
      speciesControl: new FormControl(),
      animalServiceControl: new FormControl(),
      dogWalkLengthControl: new FormControl(),
      descriptionControl: new FormControl()
    });

    this.isVisible.push(false);

    this.animalServices.push([]);
    this.petWalkLengths.push([]);

    this.animals.push(group, { emitEvent: false });

    (this.form.get('animalArrayControl')! as FormArray).at(0).get('animalTypeControl')!.markAsUntouched();
    (this.form.get('animalArrayControl')! as FormArray).at(0).get('animalTypeControl')!.markAsPristine();
  }

  public click(event: any) {
    debugger;
  }

  public onAnimalTypeSelectionChange(event: MatSelectChange, index: number) {
    this.FormArrayControls.at(index).get('speciesControl')!.reset();
    this.FormArrayControls.at(index).get('animalServiceControl')!.reset();
    this.FormArrayControls.at(index).get('dogWalkLengthControl')!.reset();
    this.FormArrayControls.at(index).get('descriptionControl')!.reset();

    this.currentlySelectedPet = event.value.displayName;

    if (event.value.displayName === 'Друго') {
      this.animalServices[index] = [];
      this.petWalkLengths[index] = [];
      this.isVisible[index] = false;
    } else if (event.value.displayName === 'Котка') {
      this.animalServices[index] = this.catServices;
      this.petWalkLengths[index] = [];
      this.isVisible[index] = true;
    } else if (event.value.displayName === 'Малко куче') {
      this.animalServices[index] = this.smallDogServices;
      this.petWalkLengths[index] = this.smallDogWalkLengths;
      this.isVisible[index] = true;
    } else if (event.value.displayName === 'Голямо куче') {
      this.animalServices[index] = this.bigDogServices;
      this.petWalkLengths[index] = this.bigDogWalkLengths;
      this.isVisible[index] = true;
    }
  }

  public isOthersSelected(index: number): boolean | undefined {
    if (!this.FormArrayControls.at(index).get('animalTypeControl')!.value) {
      return undefined;
    }

    return this.FormArrayControls.at(index).get('animalTypeControl')!.value.displayName === 'Друго';
  }

  public displayFn(data: NomenclatureDTO<number>): string {
    return data && data.displayName ? data.displayName : '';
  }

  public submitForm() {


    if (this.form.valid) {
      const dateLocationGroup = this.form.controls['dateLocationGroupControl'];

      const customerServicesControl = this.form.controls['customerServiceControl'];

      const pets: EditPetDTO[] = [];

      const customerServices: number[] = [];

      const comment: string | undefined = this.form.controls['commentControl'].value;

      if (customerServicesControl.value && Array.isArray(customerServicesControl.value)) {
        for (let service of customerServicesControl.value) {
          customerServices.push(service.value);
        }
      }

      for (let group of this.animals.controls) {
        const pet: EditPetDTO = new EditPetDTO();

        pet.name = group.get('nameControl')!.value;
        pet.species = group.get('speciesControl')!.value;
        pet.petDescription = group.get('descriptionControl')!.value,
          pet.animalTypeId = group.get('animalTypeControl')!.value?.value ?? group.get('animalTypeControl')!.value;
        pet.services = [];

        if (group.get('animalServiceControl')!.value && Array.isArray(group.get('animalServiceControl')!.value)) {

          for (let service of group.get('animalServiceControl')!.value) {
            pet.services.push(service.value);
          }
        }

        if (group.get('dogWalkLengthControl')!.value) {
          pet.services.push(group.get('dogWalkLengthControl')!.value.value);
        }

        pets.push(pet);
      }

      const startDate: Date = new Date(dateLocationGroup.get('startDateControl')!.value);
      const endDate: Date = new Date(dateLocationGroup.get('endDateControl')!.value);
      const meetingDate: Date = new Date(dateLocationGroup.get('meetingDateControl')!.value);
      const form = new EditRequestDTO({
        locationId: dateLocationGroup.get('locationControl')!.value?.value ?? dateLocationGroup.get('locationControl')!.value,
        startDate: startDate,
        endDate: endDate,
        isAccepted: false,
        isRead: false,
        meetingDate: meetingDate,
        comment: comment,
        userId: sessionStorage.getItem('id')!,
        totalAmount: this.finalPrice,
        services: customerServices,
        pets: pets
      });

      this.service.submitForm(form).subscribe();
    }
  }
}
