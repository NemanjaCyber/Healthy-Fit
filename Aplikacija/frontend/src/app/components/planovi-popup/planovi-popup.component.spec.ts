import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanoviPopupComponent } from './planovi-popup.component';

describe('PlanoviPopupComponent', () => {
  let component: PlanoviPopupComponent;
  let fixture: ComponentFixture<PlanoviPopupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanoviPopupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanoviPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
