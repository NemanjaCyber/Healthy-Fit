import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikPorukaPopupComponent } from './korisnik-poruka-popup.component';

describe('KorisnikPorukaPopupComponent', () => {
  let component: KorisnikPorukaPopupComponent;
  let fixture: ComponentFixture<KorisnikPorukaPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisnikPorukaPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KorisnikPorukaPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
