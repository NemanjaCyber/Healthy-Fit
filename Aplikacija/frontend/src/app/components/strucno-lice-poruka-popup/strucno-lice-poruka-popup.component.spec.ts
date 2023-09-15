import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnoLicePorukaPopupComponent } from './strucno-lice-poruka-popup.component';

describe('StrucnoLicePorukaPopupComponent', () => {
  let component: StrucnoLicePorukaPopupComponent;
  let fixture: ComponentFixture<StrucnoLicePorukaPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnoLicePorukaPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnoLicePorukaPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
