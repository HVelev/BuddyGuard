import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../../services/register.service';
import { createPopper } from '@popperjs/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { RegisterDTO } from '../../models/register.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { StringNomenclatureDTO } from '../../shared/models/string-nomenclature-dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  private service: RegisterService;
  private snackbar: MatSnackBar;
  private router: Router;

  public form: FormGroup;
  public roles: StringNomenclatureDTO[] = [];

  public constructor(service: RegisterService,
    snackbar: MatSnackBar,
    router: Router
  ) {
    this.service = service;

    this.snackbar = snackbar;

    this.form = new FormGroup({
      emailControl: new FormControl(undefined, Validators.required),
      usernameControl: new FormControl(undefined, Validators.required),
      passwordControl: new FormControl(undefined, Validators.required),
      confirmPasswordControl: new FormControl(undefined, Validators.required),
      roleControl: new FormControl(undefined, Validators.required),
      phoneControl: new FormControl(undefined, Validators.required),
      firstNameControl: new FormControl(undefined, Validators.required),
      lastNameControl: new FormControl(undefined, Validators.required),
      addressControl: new FormControl(undefined, Validators.required),
    }, this.passwordMatchingValidatior);

    this.router = router;
  }

  public ngOnInit(): void {
    this.service.getRoles().subscribe({
      next: (value: StringNomenclatureDTO[]) => {
        this.roles = value;
      }
    });
  }

  public register(): void {
    const formDTO = new RegisterDTO({
      email: this.form.get('emailControl')!.value,
      username: this.form.get('usernameControl')!.value,
      address: this.form.get('addressControl')!.value,
      firstName: this.form.get('firstNameControl')!.value,
      lastName: this.form.get('lastNameControl')!.value,
      phone: this.form.get('phoneControl')!.value,
      password: this.form.get('passwordControl')!.value,
      role: this.form.get('roleControl')!.value!.displayName,
    });

    this.service.register(formDTO).subscribe({
      next: () => {
        this.router.navigate(['/login']);
      },
      error: (error: any) => {
        if (error.status === 422) {
          this.snackbar.open('Вече съществува потребител със същия имейл', "Close", {
            duration: 2000,
            panelClass: 'red-snackbar'
          });
        }
      }
    });
  }

  private passwordMatchingValidatior: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
    const password = control.get('passwordControl');
    const confirmPassword = control.get('confirmPasswordControl');

    return password?.value === confirmPassword?.value ? null : { notmatched: true };
  }
}
