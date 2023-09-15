import { TestBed } from '@angular/core/testing';

import { OcenaKomentarService } from './ocena-komentar.service';

describe('OcenaKomentarService', () => {
  let service: OcenaKomentarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OcenaKomentarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
