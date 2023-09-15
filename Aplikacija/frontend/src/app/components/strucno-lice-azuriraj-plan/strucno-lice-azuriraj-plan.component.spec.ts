import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnoLiceAzurirajPlanComponent } from './strucno-lice-azuriraj-plan.component';

describe('StrucnoLiceAzurirajPlanComponent', () => {
  let component: StrucnoLiceAzurirajPlanComponent;
  let fixture: ComponentFixture<StrucnoLiceAzurirajPlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnoLiceAzurirajPlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnoLiceAzurirajPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
