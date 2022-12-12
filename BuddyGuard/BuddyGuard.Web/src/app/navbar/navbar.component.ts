import { animate, state, style, transition, trigger } from '@angular/animations';
import { MediaMatcher } from '@angular/cdk/layout';
import { DatePipe } from '@angular/common';
import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { EditRequestDTO } from '../models/edit-request.model';
import { RequestDTO } from '../models/request.model';
import { ProcessRequestDialogComponent } from '../pages/process-request/models/process-request-dialog/process-request-dialog.component';
import { LoginService } from '../services/login.service';
import { ProcessRequestService } from '../services/process-request.service';
import { RegisterService } from '../services/register.service';
import { RequestService } from '../services/request.service';


const enterTransition = transition('openClose', [
  style({
    opacity: 0
  }),
  animate('1s ease-in', style({
    opacity: 1
  }))
]);

const leaveTrans = transition('closed', [
  style({
    opacity: 1
  }),
  animate('1s ease-out', style({
    opacity: 0
  }))
])

const fadeIn = trigger('fadeIn', [
  enterTransition
]);

const fadeOut = trigger('fadeOut', [
  leaveTrans
]);

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  animations: [
    trigger('flyInOut', [
      state('in', style({ transform: 'translateX(0)' })),
      transition('void => *', [
        style({ transform: 'translateX(-100%)' }),
        animate(100)
      ]),
      transition('* => void', [
        animate(100, style({ transform: 'translateX(100%)' }))
      ])
    ])
  ]
})
export class NavbarComponent implements OnInit {
  @ViewChild('snav') navElement!: MatSidenav;

  private requestService: RequestService;
  private loginService: LoginService;
  private registerService: RegisterService;
  private router: Router;
  private dialog: MatDialog;

  public eventsSubject: Subject<void> = new Subject<void>();


  public isToggled = true;
  public notifications: RequestDTO[] = [];
  public role: string | undefined | null;
  public datePipe: DatePipe;

  mobileQuery: MediaQueryList;

  fillerNav = Array.from({ length: 50 }, (_, i) => `Nav Item ${i + 1}`);

  fillerContent = Array.from(
    { length: 50 },
    () =>
      `Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
       labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco
       laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in
       voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat
       cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.`,
  );

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    requestService: RequestService,
    loginService: LoginService,
    registerService: RegisterService,
    datePipe: DatePipe,
    router: Router,
    dialog: MatDialog
  ) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.requestService = requestService;
    this.loginService = loginService;
    this.role = sessionStorage.getItem('role');
    this.registerService = registerService;
    this.datePipe = datePipe;
    this.router = router;
    this.dialog = dialog;
  }

  public ngOnInit(): void {
    this.loginService.onUserLogin.subscribe({
      next: (value: string) => {
        this.role = value;

        if (value === 'Admin') {
          this.updateNotifications();
        }
      }
    });

    this.requestService.onRequestDialogClosed.subscribe({
      next: () => {
        this.updateNotifications();
      }
    });

    if (this.loginService.isLoggedInAsAdmin(sessionStorage.getItem('token') ?? '')) {
      this.updateNotifications();
    }
  }

  public ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  public openRequestDialog(id: number) {
    this.openRequest(id);
  }

  public openRequest(id: number) {
    this.requestService.markRequestAsRead(id).subscribe();

    this.requestService.getRequest(id).subscribe({
      next: (value: any) => {
        const dialogRef = this.dialog.open(ProcessRequestDialogComponent, {
          width: '100%',
          height: '100%',
          maxWidth: '100%',
          data: value
        });

        dialogRef.afterClosed().subscribe({
          next: () => {
            this.updateNotifications();
          }
        });
      }
    });
  }

  public logout() {
    this.loginService.logout();
    this.role = undefined;
    this.loginService.onUserLogout.next();
  }

  public scrollUp() {
    window.scroll({
      top: 0,
      left: 0,
      behavior: 'smooth'
    });
  }

  public updateNotifications(): void {
    this.requestService.getAllUnreadRequests().subscribe({
      next: (value: RequestDTO[]) => {
        this.notifications = value;
        console.log(value);
      }
    });
  }

  public emitEventToChild() {
    this.eventsSubject.next();
  }
}

