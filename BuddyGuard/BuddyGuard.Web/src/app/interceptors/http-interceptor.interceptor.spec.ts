import { HttpInterceptor } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { HttpInterceptorService } from './http-interceptor.interceptor';


describe('HttpInterceptorInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      HttpInterceptorService
      ]
  }));

  it('should be created', () => {
    const interceptor: HttpInterceptor = TestBed.inject(HttpInterceptorService);
    expect(interceptor).toBeTruthy();
  });
});
