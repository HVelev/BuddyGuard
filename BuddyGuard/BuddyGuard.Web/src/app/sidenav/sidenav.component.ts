import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Observable, Subscription } from 'rxjs';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit, AfterViewInit {

  @ViewChild('snav') navElement!: MatSidenav;

  @Input() events!: Observable<void>;

  private eventsSubscription!: Subscription;
  private loginService: LoginService;

  public isToggled = true;
  public role: string | undefined | null;

  constructor(loginService: LoginService) {
    this.loginService = loginService;
  }

  ngOnInit(): void {
    this.role = sessionStorage.getItem('role');

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

    this.eventsSubscription = this.events.subscribe(() => { this.navElement.toggle(); });
  }

  public ngAfterViewInit(): void {
    this.navElement._animationStarted.subscribe({
      next: () => {
        this.isToggled = this.navElement.opened;
      }
    });

    this.navElement.fixedInViewport = true;
  }

}
