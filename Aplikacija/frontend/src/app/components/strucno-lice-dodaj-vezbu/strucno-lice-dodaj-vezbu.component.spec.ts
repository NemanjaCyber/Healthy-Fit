import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnoLiceDodajVezbuComponent } from './strucno-lice-dodaj-vezbu.component';

describe('StrucnoLiceDodajVezbuComponent', () => {
  let component: StrucnoLiceDodajVezbuComponent;
  let fixture: ComponentFixture<StrucnoLiceDodajVezbuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnoLiceDodajVezbuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnoLiceDodajVezbuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
