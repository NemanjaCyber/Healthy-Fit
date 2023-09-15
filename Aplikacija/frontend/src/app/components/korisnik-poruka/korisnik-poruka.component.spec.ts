import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikPorukaComponent } from './korisnik-poruka.component';

describe('KorisnikPorukaComponent', () => {
  let component: KorisnikPorukaComponent;
  let fixture: ComponentFixture<KorisnikPorukaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisnikPorukaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KorisnikPorukaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
