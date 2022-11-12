import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../../services/register.service';
import { createPopper } from '@popperjs/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  private service: RegisterService;

  constructor(service: RegisterService) {
    this.service = service;
  }

  ngOnInit(): void {
  }

  public register(): void {
    this.service.register().subscribe();
  }
}
