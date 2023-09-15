import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikStrucnaLicaPopupComponent } from './korisnik-strucna-lica-popup.component';

describe('KorisnikStrucnaLicaPopupComponent', () => {
  let component: KorisnikStrucnaLicaPopupComponent;
  let fixture: ComponentFixture<KorisnikStrucnaLicaPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisnikStrucnaLicaPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KorisnikStrucnaLicaPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
