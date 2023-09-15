import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnoLiceDodajObrokComponent } from './strucno-lice-dodaj-obrok.component';

describe('StrucnoLiceDodajObrokComponent', () => {
  let component: StrucnoLiceDodajObrokComponent;
  let fixture: ComponentFixture<StrucnoLiceDodajObrokComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnoLiceDodajObrokComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnoLiceDodajObrokComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
