import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnoLiceNapraviPlanComponent } from './strucno-lice-napravi-plan.component';

describe('StrucnoLiceNapraviPlanComponent', () => {
  let component: StrucnoLiceNapraviPlanComponent;
  let fixture: ComponentFixture<StrucnoLiceNapraviPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnoLiceNapraviPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnoLiceNapraviPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
