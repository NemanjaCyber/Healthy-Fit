import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistracijaStrucnoLiceComponent } from './registracija-strucno-lice.component';

describe('RegistracijaStrucnoLiceComponent', () => {
  let component: RegistracijaStrucnoLiceComponent;
  let fixture: ComponentFixture<RegistracijaStrucnoLiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegistracijaStrucnoLiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistracijaStrucnoLiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
