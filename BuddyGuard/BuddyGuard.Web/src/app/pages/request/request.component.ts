import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FormDTO } from '../../models/form.models';
import { RequestService } from '../../services/request.service';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {
  public form: FormGroup;
  private service: RequestService;

  constructor(service: RequestService) {
    this.service = service;

    this.form = new FormGroup({
      emailControl: new FormControl(undefined, [Validators.required, Validators.email]),
      phoneControl: new FormControl(undefined, [Validators.required, Validators.minLength(10), Validators.maxLength(10)]),
      nameControl: new FormControl(undefined, Validators.required),
      locationControl: new FormControl(undefined, Validators.required),
      speciesControl: new FormControl(undefined, Validators.required),
      dogWalkControl: new FormControl(),
      startControl: new FormControl(undefined, Validators.required),
      endControl: new FormControl(undefined, Validators.required)
    });
  }

  ngOnInit(): void {

  }
  public date = new Date();

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
