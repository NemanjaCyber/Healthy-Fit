import { TestBed } from '@angular/core/testing';

import { StrucnoLiceService } from './strucno-lice.service';

describe('StrucnoLiceService', () => {
  let service: StrucnoLiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StrucnoLiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
