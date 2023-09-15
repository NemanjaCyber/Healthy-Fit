import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StrucnoLiceMojiPlanoviPopupComponent } from './strucno-lice-moji-planovi-popup.component';

describe('StrucnoLiceMojiPlanoviPopupComponent', () => {
  let component: StrucnoLiceMojiPlanoviPopupComponent;
  let fixture: ComponentFixture<StrucnoLiceMojiPlanoviPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StrucnoLiceMojiPlanoviPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StrucnoLiceMojiPlanoviPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
