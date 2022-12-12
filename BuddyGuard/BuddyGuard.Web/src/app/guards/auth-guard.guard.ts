import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { LoginService } from '../services/login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  private readonly service: LoginService;
  private readonly router: Router;
  public constructor
    (
      service: LoginService,
      router: Router
    ) {
    this.service = service;
    this.router = router;
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    switch (state.url) {
      case '/login':
        const obsLogin = this.service.isLoggedIn(sessionStorage.getItem('token') ?? '');

        obsLogin.subscribe({
          next: (value: boolean) => {
            if (value) {
              this.router.navigate(['/']);
            }
          }
        });

        return obsLogin;
      case '/register':
        const obsRegister = this.service.isLoggedIn(sessionStorage.getItem('token') ?? '');

        obsRegister.subscribe({
          next: (value: boolean) => {
            if (value) {
              this.router.navigate(['/']);
            }
          }
        });

        return obsRegister;
      case '/request':
        const obsRequest = this.service.isLoggedInAsUser(sessionStorage.getItem('token') ?? '');

        obsRequest.subscribe({
          next: (value: boolean) => {
            if (!value) {
              this.router.navigate(['/']);
            }
          }
        });

        return obsRequest;
      case '/process-request':
        const obsProcess = this.service.isLoggedInAsAdmin(sessionStorage.getItem('token') ?? '');

        obsProcess.subscribe({
          next: (value: boolean) => {
            if (!value) {
              this.router.navigate(['/']);
            }
          }
        });

        return obsProcess;
      case '/accept-requests':
        const obsAccept = this.service.isLoggedInAsAdmin(sessionStorage.getItem('token') ?? '');

        obsAccept.subscribe({
          next: (value: boolean) => {
            if (!value) {
              this.router.navigate(['/']);
            }
          }
        });

        return obsAccept;
      case '/buddies':
        const obsBuddies = this.service.isLoggedIn(sessionStorage.getItem('token') ?? '');

        obsBuddies.subscribe({
          next: (value: boolean) => {
            if (!value) {
              this.router.navigate(['/']);
            }
          }
        });

        return obsBuddies;
      case '/price':
        return new Promise((resolve, reject) => {
          let isAdmin: boolean = false;

          this.service.isLoggedInAsAdmin(sessionStorage.getItem('token') ?? '').subscribe({
            next: (value: boolean) => {
              isAdmin = value;
              if (isAdmin) {
                this.router.navigate(['/']);
                resolve(false);
              } else {
                resolve(true);
              }
            }
          });
        });
      case '/about':
        return new Promise((resolve, reject) => {
          let isAdmin: boolean = false;

          this.service.isLoggedInAsAdmin(sessionStorage.getItem('token') ?? '').subscribe({
            next: (value: boolean) => {
              isAdmin = value;
              if (isAdmin) {
                this.router.navigate(['/']);
                resolve(false);
              } else {
                resolve(true);
              }
            }
          });
        });
    }

    this.router.navigate(['/']);
    return false;
  }

}
