import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
  private loginService: LoginService;

  public role: string | null;

  public constructor(loginService: LoginService) {
    this.loginService = loginService;

    this.role = sessionStorage.getItem('role');
}

  public ngOnInit(): void {
    this.loginService.onUserLogin.subscribe({
      next: (value: string) => {
        this.role = value;
      }
    });

    this.loginService.onUserLogout.subscribe({
      next: () => {
        this.role = null;
      }
    });
  }
}
