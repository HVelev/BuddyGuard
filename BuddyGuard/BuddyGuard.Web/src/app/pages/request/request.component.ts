import { AfterViewInit, Component, ContentChild, OnChanges, OnInit, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { AbstractControl, FormArray, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { MomentDateAdapter } from '@angular/material-moment-adapter';
import { DateAdapter, ErrorStateMatcher, MAT_DATE_FORMATS, MAT_DATE_LOCALE, ShowOnDirtyErrorStateMatcher } from '@angular/material/core';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatSelect, MatSelectChange } from '@angular/material/select';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatStep, MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import { map, startWith } from 'rxjs';
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
export class RequestComponent implements OnInit, AfterViewInit {
  private service: RequestService;
  private snackbar: MatSnackBar;
  private router: Router;

  @ViewChild('animalType')
  public animalTypeMatSelect!: MatSelect;
  @ViewChild('stepper')
  public stepper!: MatStepper;
  @ViewChild('picker')
  public startDate!: MatDatepicker<Date>;
  @ViewChild('pick')
  public endDate!: MatDatepicker<Date>;

  public form: FormGroup;
  public animalTypes: NomenclatureDTO<number>[] = [];
  public locations: NomenclatureDTO<number>[] = [];
  public locationOptions: NomenclatureDTO<number>[] = [];
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
    nameControl: new FormControl(undefined, [Validators.required, Validators.maxLength(100)]),
    animalTypeControl: new FormControl(undefined, Validators.required),
    speciesControl: new FormControl(),
    animalServiceControl: new FormControl(),
    dogWalkLengthControl: new FormControl(),
    descriptionControl: new FormControl()
  })]);

  public get formArrayControls(): FormArray {
    return this.form.get('animalArrayControl') as FormArray;
  }

  public get dateLocationGroup(): FormGroup {
    return this.form.get('dateLocationGroupControl') as FormGroup;
  }

  public constructor(service: RequestService,
    private dateAdapter: DateAdapter<Date>,
    snackbar: MatSnackBar,
    router: Router
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
        this.locationOptions = value;
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
        startDateControl: new FormControl(undefined, Validators.required),
        endDateControl: new FormControl(undefined, Validators.required),
        meetingDateControl: new FormControl(),
        locationControl: new FormControl(undefined, [Validators.required, requireMatch()]),
        addressControl: new FormControl(undefined, Validators.required)
      }),
      customerServiceControl: new FormControl(),
      commentControl: new FormControl()
    });

    this.router = router;

    this.snackbar = snackbar;
  }

  public ngOnInit(): void {
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

    this.dateLocationGroup.get('locationControl')!.valueChanges
      .pipe(
        startWith(''),
        map(val => this.filter(val))
      )
      .subscribe({
        next: (value: NomenclatureDTO<number>[]) => {
          this.locations = value;
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

    this.startDate.openedStream.subscribe({
      next: () => {
        this.dateLocationGroup.get('startDateControl')!.removeValidators(Validators.required);
        this.dateLocationGroup.get('startDateControl')!.updateValueAndValidity();
      }
    });

    this.startDate.closedStream.subscribe({
      next: () => {
        this.dateLocationGroup.get('startDateControl')!.addValidators(Validators.required);
        this.dateLocationGroup.get('startDateControl')!.updateValueAndValidity();
      }
    });

    this.endDate.openedStream.subscribe({
      next: () => {
        this.dateLocationGroup.get('endDateControl')!.removeValidators(Validators.required);
        this.dateLocationGroup.get('endDateControl')!.updateValueAndValidity();
      }
    });

    this.endDate.closedStream.subscribe({
      next: () => {
        this.dateLocationGroup.get('endDateControl')!.addValidators(Validators.required);
        this.dateLocationGroup.get('endDateControl')!.updateValueAndValidity();
      }
    });
  }

  public getDays(startDate: Date, endDate: Date): number {
    const msInDay = 24 * 60 * 60 * 1000;

    return Math.round(Math.abs(Number(endDate) - Number(startDate)) / msInDay) + 1;
  }

  public calculate() {
    this.finalPrice = 0;

    for (let control of this.formArrayControls.controls) {
      if (control.get('dogWalkLengthControl')!.value) {
        this.finalPrice += control.get('dogWalkLengthControl')!.value.price;
      }

      if (control.get('animalServiceControl')!.value) {
        for (let service of control.get('animalServiceControl')!.value) {
          this.finalPrice += service.price;
        }
      }
    }

    this.finalPrice += this.getDays(this.form.get('dateLocationGroupControl')!.get('startDateControl')!.value, this.form.get('dateLocationGroupControl')!.get('endDateControl')!.value) * 9.99 * this.formArrayControls.length;

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

  public onAnimalTypeSelectionChange(event: MatSelectChange, index: number) {
    this.formArrayControls.at(index).get('speciesControl')!.reset();
    this.formArrayControls.at(index).get('animalServiceControl')!.reset();
    this.formArrayControls.at(index).get('dogWalkLengthControl')!.reset();
    this.formArrayControls.at(index).get('descriptionControl')!.reset();

    this.currentlySelectedPet = event.value.displayName;

    if (event.value.displayName === '??????????') {
      this.animalServices[index] = [];
      this.petWalkLengths[index] = [];
      this.isVisible[index] = false;
      this.formArrayControls.at(index).get('descriptionControl')!.setValidators(Validators.required);
      this.formArrayControls.at(index).get('descriptionControl')!.updateValueAndValidity();
    } else if (event.value.displayName === '??????????') {
      this.animalServices[index] = this.catServices;
      this.petWalkLengths[index] = [];
      this.isVisible[index] = true;
      this.formArrayControls.at(index).get('descriptionControl')!.removeValidators(Validators.required);
      this.formArrayControls.at(index).get('descriptionControl')!.updateValueAndValidity();
    } else if (event.value.displayName === '?????????? ????????') {
      this.animalServices[index] = this.smallDogServices;
      this.petWalkLengths[index] = this.smallDogWalkLengths;
      this.isVisible[index] = true;
      this.formArrayControls.at(index).get('descriptionControl')!.removeValidators(Validators.required);
      this.formArrayControls.at(index).get('descriptionControl')!.updateValueAndValidity();
    } else if (event.value.displayName === '???????????? ????????') {
      this.animalServices[index] = this.bigDogServices;
      this.petWalkLengths[index] = this.bigDogWalkLengths;
      this.isVisible[index] = true;
      this.formArrayControls.at(index).get('descriptionControl')!.removeValidators(Validators.required);
      this.formArrayControls.at(index).get('descriptionControl')!.updateValueAndValidity();
    }
  }

  public isOthersSelected(index: number): boolean | undefined {
    if (!this.formArrayControls.at(index).get('animalTypeControl')!.value) {
      return undefined;
    }

    return this.formArrayControls.at(index).get('animalTypeControl')!.value.displayName === '??????????';
  }

  public displayFn(data: NomenclatureDTO<number>): string {
    return data && data.displayName ? data.displayName : '';
  }

  public filter(val: string | NomenclatureDTO<number>): NomenclatureDTO<number>[] {
    if (typeof val === 'string') {
      return this.locationOptions.filter(location =>
        location.displayName.toLowerCase().includes(val.toLowerCase()));
    } else {
      return this.locationOptions.filter(location =>
        location.displayName.toLowerCase().includes(val.displayName));
    }
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
        pet.petDescription = group.get('descriptionControl')!.value;
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
      const meetingDate: Date | undefined = dateLocationGroup.get('meetingDateControl')!.value ? new Date(dateLocationGroup.get('meetingDateControl')!.value) : undefined;
      const location: number = dateLocationGroup.get('locationControl')!.value!.value;
      const address: string = dateLocationGroup.get('addressControl')!.value;

      const form = new EditRequestDTO({
        locationId: location,
        address: address,
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

      this.service.submitForm(form).subscribe({
        next: () => {
          this.router.navigate(['/']);

          this.snackbar.open("?????????????? ???????????????? ??????????. ?????????????????? ?????????????? ???? ??????????!", "??????????????", {
            duration: 4000
          });
        }
      });
    }
  }
}

export function requireMatch(): ValidatorFn {
  console.log('isnide');
  return (control: AbstractControl): ValidationErrors | null => {
    if (typeof control.value === 'string') {
      return { 'requirematch': true };
    }

    return null;
  }
}
