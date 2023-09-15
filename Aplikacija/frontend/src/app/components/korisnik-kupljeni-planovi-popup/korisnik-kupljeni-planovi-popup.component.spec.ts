import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikKupljeniPlanoviPopupComponent } from './korisnik-kupljeni-planovi-popup.component';

describe('KorisnikKupljeniPlanoviPopupComponent', () => {
  let component: KorisnikKupljeniPlanoviPopupComponent;
  let fixture: ComponentFixture<KorisnikKupljeniPlanoviPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisnikKupljeniPlanoviPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KorisnikKupljeniPlanoviPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
