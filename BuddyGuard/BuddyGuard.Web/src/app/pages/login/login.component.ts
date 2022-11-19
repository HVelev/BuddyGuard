import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { LoginDTO } from '../../models/login.model';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private service: LoginService;
  private router: Router;
  private snackbar: MatSnackBar;

  public form: FormGroup;

  constructor(service: LoginService, router: Router, snackbar: MatSnackBar)
  {
    this.service = service;
    this.form = new FormGroup({
      usernameControl: new FormControl(undefined, Validators.required),
      passwordControl: new FormControl(undefined, Validators.required)
    });
    this.router = router;
    this.snackbar = snackbar;
  }

  ngOnInit(): void {
  }

  public login(): void {
    const user = new LoginDTO({
      username: this.form.controls['usernameControl'].value,
      password: this.form.controls['passwordControl'].value
    });

    this.service.login(user).subscribe({
      next: (value: any) => {
        this.service.onUserLogin.next(value.role);

        sessionStorage.setItem('token', value.token);
        sessionStorage.setItem('role', value.role);
        sessionStorage.setItem('name', value.name);
        sessionStorage.setItem('email', value.email);
        sessionStorage.setItem('phone', value.phone);

        this.router.navigate(['/']);
      },
      error: (error: any) => {
        if (error.status > 399 && error.status < 500) {
          this.snackbar.open("Грешно потребителско име или парола", "Close", {
            duration: 2000,
            panelClass: 'red-snackbar'
          });
        }
      }
    });
  }
}
