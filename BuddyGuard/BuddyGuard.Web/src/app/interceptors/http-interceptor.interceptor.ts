import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {
  private snackbar: MatSnackBar;

  constructor(snackbar: MatSnackBar) {
    this.snackbar = snackbar;
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = sessionStorage.getItem('token');

    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(request).pipe(catchError(this.handleError));
  }

  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      this.snackbar.open('Възникна грешка', 'Затвори');
    } else {
      if (error.status >= 500 || error.status === 0) {
        this.snackbar.open('Възникна сървърна грешка', 'Затвори');
      }
    }

    return throwError(error);
  }
}
