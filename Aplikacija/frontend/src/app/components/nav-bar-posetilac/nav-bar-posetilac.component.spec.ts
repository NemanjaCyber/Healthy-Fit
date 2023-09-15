import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBarPosetilacComponent } from './nav-bar-posetilac.component';

describe('NavBarPosetilacComponent', () => {
  let component: NavBarPosetilacComponent;
  let fixture: ComponentFixture<NavBarPosetilacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavBarPosetilacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavBarPosetilacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
