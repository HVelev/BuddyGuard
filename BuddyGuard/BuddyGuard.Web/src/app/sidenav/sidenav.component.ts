import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit, AfterViewInit {

  @ViewChild('snav') navElement!: MatSidenav;

  @Input() events!: Observable<void>;

  private eventsSubscription!: Subscription;

  public isToggled = true;
  public role: string | undefined | null;

  constructor() { }

  ngOnInit(): void {
    this.role = sessionStorage.getItem('role');
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
