import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnoLicePorukaComponent } from './strucno-lice-poruka.component';

describe('StrucnoLicePorukaComponent', () => {
  let component: StrucnoLicePorukaComponent;
  let fixture: ComponentFixture<StrucnoLicePorukaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnoLicePorukaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnoLicePorukaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
