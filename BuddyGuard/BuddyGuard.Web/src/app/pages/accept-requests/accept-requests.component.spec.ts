import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptRequestsComponent } from './accept-requests.component';

describe('AcceptRequestsComponent', () => {
  let component: AcceptRequestsComponent;
  let fixture: ComponentFixture<AcceptRequestsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcceptRequestsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AcceptRequestsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
