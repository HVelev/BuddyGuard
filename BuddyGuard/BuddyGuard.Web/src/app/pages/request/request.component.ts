import { AfterViewInit, Component, OnChanges, OnInit, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSelect, MatSelectChange } from '@angular/material/select';
import { PetDTO } from '../../models/pet.model';
import { RequestDTO } from '../../models/request.model';
import { RequestService } from '../../services/request.service';
import { NomenclatureDTO } from '../../shared/models/nomenclature-dto';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {
  private service: RequestService;

  @ViewChild('animalType')
  public animalTypeMatSelect!: MatSelect;

  public form: FormGroup;
  public animalTypes: NomenclatureDTO<number>[] = [];
  public locations: NomenclatureDTO<number>[] = [];
  public clientServices: NomenclatureDTO<number>[] = [];
  public smallDogServices: NomenclatureDTO<number>[] = [];
  public bigDogServices: NomenclatureDTO<number>[] = [];
  public catServices: NomenclatureDTO<number>[] = [];
  public animalServices: NomenclatureDTO<number>[][] = [];
  public animals: FormArray = new FormArray([new FormGroup({
    nameControl: new FormControl('asd', Validators.required),
    animalTypeControl: new FormControl(3, Validators.required),
    speciesControl: new FormControl(),
    animalServiceControl: new FormControl(),
    dogWalkLengthControl: new FormControl()
  })]);
  public isVisible: boolean[] = [false];
  public totalPrice: number = 0;

  public get FormArrayControls(): FormArray {
    return this.form.get('animalArrayControl') as FormArray;
  }

  public get dateLocationGroup(): FormGroup {
    return this.form.get('dateLocationGroupControl') as FormGroup;
  }

  constructor(service: RequestService
  ) {
    this.service = service;

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

    this.service.getBigDogServices().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.bigDogServices = value;
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
        locationControl: new FormControl(3, Validators.required)
      }),
      customerServiceControl: new FormControl()
    });
  }

  ngOnInit(): void {
    this.form;
    ((this.form.controls['animalArrayControl'] as FormArray).at(0) as FormGroup).controls['animalTypeControl'].valueChanges.subscribe({
      next: (value: any) => {
      }
    });
  }

  public date = new Date();

  public addAnimal() {
    const group = new FormGroup({
      nameControl: new FormControl(undefined, Validators.required),
      animalTypeControl: new FormControl(undefined, Validators.required),
      speciesControl: new FormControl(),
      animalServiceControl: new FormControl(),
      dogWalkLengthControl: new FormControl()
    });

    this.isVisible.push(false);

    this.animalServices.push([]);

    this.animals.push(group, { emitEvent: false });

    (this.form.get('animalArrayControl')! as FormArray).at(0).get('animalTypeControl')!.markAsUntouched();
    (this.form.get('animalArrayControl')! as FormArray).at(0).get('animalTypeControl')!.markAsPristine();
  }

  public click() {
    debugger;
  }

  public onAnimalTypeSelectionChange(event: MatSelectChange, index: number) {
    if (event.value.displayName === 'Друго') {
      this.isVisible[index] = false;
      this.animalServices[index] = [];
    } else if (event.value.displayName === 'Котка') {
      this.animalServices[index] = this.catServices;
      this.isVisible[index] = true;
    } else if (event.value.displayName === 'Малко куче') {
      this.animalServices[index] = this.smallDogServices;
      this.isVisible[index] = true;
    } else if (event.value.displayName === 'Голямо куче') {
      this.animalServices[index] = this.bigDogServices;
      this.isVisible[index] = true;
    }
  }

  public displayFn(data: NomenclatureDTO<number>): string {
    return data && data.displayName ? data.displayName : '';
  }


  public submitForm() {
    if (this.form.valid) {
      const dateLocationGroup = this.form.controls['dateLocationGroupControl'];

      const customerServicesControl = this.form.controls['customerServiceControl'];

      const pets: PetDTO[] = [];

      const customerServices: number[] = [];

      for (let service of customerServicesControl.value) {
        customerServices.push(service.value);
      }

      for (let group of this.animals.controls) {
        const pet: PetDTO = new PetDTO();

        pet.name = group.get('nameControl')!.value;
        pet.species = group.get('speciesControl')!.value;
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

      const startDate: Date = dateLocationGroup.get('startDateControl')!.value;

      const form = new RequestDTO({
        locationId: dateLocationGroup.get('locationControl')!.value?.value ?? dateLocationGroup.get('locationControl')!.value,
        startDate: dateLocationGroup.get('startDateControl')!.value,
        endDate: dateLocationGroup.get('endDateControl')!.value,
        isAccepted: false,
        isRead: false,
        userId: sessionStorage.getItem('id')!,
        totalAmount: this.totalPrice,
        services: customerServices,
        pets: pets
      });

      this.service.submitForm(form).subscribe();
    }
  }
}
