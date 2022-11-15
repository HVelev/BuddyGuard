import { TestBed } from '@angular/core/testing';

import { ProcessRequestService } from './process-request.service';

describe('ProcessRequestService', () => {
  let service: ProcessRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProcessRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
