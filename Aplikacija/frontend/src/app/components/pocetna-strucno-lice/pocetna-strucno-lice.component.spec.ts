import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PocetnaStrucnoLiceComponent } from './pocetna-strucno-lice.component';

describe('PocetnaStrucnoLiceComponent', () => {
  let component: PocetnaStrucnoLiceComponent;
  let fixture: ComponentFixture<PocetnaStrucnoLiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PocetnaStrucnoLiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PocetnaStrucnoLiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
