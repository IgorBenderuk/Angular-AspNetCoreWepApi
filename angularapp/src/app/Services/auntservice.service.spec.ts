import { TestBed } from '@angular/core/testing';

import { Auntservice } from './auntservice.service';

describe('AuntserviceService', () => {
  let service: Auntservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Auntservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
