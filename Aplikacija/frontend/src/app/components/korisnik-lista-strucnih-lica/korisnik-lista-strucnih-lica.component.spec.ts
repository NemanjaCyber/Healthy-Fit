import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikListaStrucnihLicaComponent } from './korisnik-lista-strucnih-lica.component';

describe('KorisnikListaStrucnihLicaComponent', () => {
  let component: KorisnikListaStrucnihLicaComponent;
  let fixture: ComponentFixture<KorisnikListaStrucnihLicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisnikListaStrucnihLicaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KorisnikListaStrucnihLicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
