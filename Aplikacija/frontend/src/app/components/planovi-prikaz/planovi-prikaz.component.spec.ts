import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanoviPrikazComponent } from './planovi-prikaz.component';

describe('PlanoviPrikazComponent', () => {
  let component: PlanoviPrikazComponent;
  let fixture: ComponentFixture<PlanoviPrikazComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanoviPrikazComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanoviPrikazComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
