import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginDTO } from '../../models/login.model';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private service: LoginService;

  public form: FormGroup;

  constructor(service: LoginService)
  {
    this.service = service;
    this.form = new FormGroup({
      usernameControl: new FormControl(undefined, Validators.required),
      passwordControl: new FormControl(undefined, Validators.required)
    });
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
        sessionStorage.setItem('token', value.token);
      }
    });
  }
}
