import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { FormDTO } from '../../models/form.model';
import { RequestService } from '../../services/request.service';
import { NomenclatureDTO } from '../../shared/models/nomenclature-dto';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {
  private service: RequestService;

  public form: FormGroup;
  public animalTypes: NomenclatureDTO<number>[] = [];
  public locations: NomenclatureDTO<number>[] = [];
  public clientServices: NomenclatureDTO<number>[] = [];
  public smallDogServices: NomenclatureDTO<number>[] = [];
  public bigDogServices: NomenclatureDTO<number>[] = [];
  public catServices: NomenclatureDTO<number>[] = [];
  public animals: FormArray = new FormArray([new FormGroup({
    nameControl: new FormControl(1, Validators.required),
    animalTypeControl: new FormControl(undefined, Validators.required),
    speciesControl: new FormControl(),
    animalServiceGroupControl: new FormGroup({
      combControl: new FormControl(),
      walkControl: new FormControl(),
      bathControl: new FormControl()
    })
  })]);

  public get FormArrayControls(): FormArray {
    return this.form.get('animalArrayControl') as FormArray;
  }

  public get dateLocationGroup(): FormGroup {
    return this.form.get('dateLocationGroupControl') as FormGroup;
  }

  constructor(service: RequestService) {
    this.service = service;

    this.service.getAnimalTypes().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.animalTypes = value;
      }
    });

    this.service.getLocations().subscribe({
      next: (value: NomenclatureDTO<number>[]) => {
        this.locations = value;
        debugger;
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

    this.service.getClientServices().subscribe({
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
        locationControl: new FormControl(undefined, Validators.required)
      }),
      customerServiceControl: new FormControl()
    });
  }

  ngOnInit(): void {
    this.form;
    debugger;
  }

  public date = new Date();

  public addAnimal() {
    const group = new FormGroup({
      nameControl: new FormControl(undefined, Validators.required),
      animalTypeControl: new FormControl(undefined, Validators.required),
      speciesControl: new FormControl(),
      animalServiceGroup: new FormGroup({
        combControl: new FormControl(),
        walkControl: new FormControl(),
        bathControl: new FormControl()
      })
    });


    this.animals.push(group, { emitEvent: false });
    debugger;

    (this.form.get('animalArrayControl')! as FormArray).at(0).get('animalTypeControl')!.markAsUntouched();
    (this.form.get('animalArrayControl')! as FormArray).at(0).get('animalTypeControl')!.markAsPristine();
  }

  public click() {
    debugger;
  }

  public displayFn(data: NomenclatureDTO<number>): string {
    return data && data.displayName ? data.displayName : '';
  }


  public submitForm() {
    if (this.form.valid) {
      const form = new FormDTO({
        name: this.form.get('nameControl')!.value,
        email: this.form.get('emailControl')!.value,
        phone: this.form.get('phoneControl')!.value,
        location: this.form.get('locationControl')?.value,
        startDate: this.form.get('startControl')!.value,
        endDate: this.form.get('endControl')!.value,
        dogWalk: this.form.get('dogWalkControl')!.value,
        species: this.form.get('speciesControl')!.value
      });

      this.service.submitForm(form).subscribe({
        next: (value: string) => {
          debugger;
        }
      });
    }
  }
}
