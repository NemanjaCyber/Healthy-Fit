import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilStrucnoLiceComponent } from './profil-strucno-lice.component';

describe('ProfilStrucnoLiceComponent', () => {
  let component: ProfilStrucnoLiceComponent;
  let fixture: ComponentFixture<ProfilStrucnoLiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfilStrucnoLiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfilStrucnoLiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
