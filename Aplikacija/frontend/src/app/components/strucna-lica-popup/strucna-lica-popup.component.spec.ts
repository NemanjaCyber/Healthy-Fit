import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnaLicaPopupComponent } from './strucna-lica-popup.component';

describe('StrucnaLicaPopupComponent', () => {
  let component: StrucnaLicaPopupComponent;
  let fixture: ComponentFixture<StrucnaLicaPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnaLicaPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnaLicaPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
