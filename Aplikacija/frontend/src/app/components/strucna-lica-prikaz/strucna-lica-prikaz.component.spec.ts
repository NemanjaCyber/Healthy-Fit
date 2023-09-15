import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnaLicaPrikazComponent } from './strucna-lica-prikaz.component';

describe('StrucnaLicaPrikazComponent', () => {
  let component: StrucnaLicaPrikazComponent;
  let fixture: ComponentFixture<StrucnaLicaPrikazComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnaLicaPrikazComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnaLicaPrikazComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
