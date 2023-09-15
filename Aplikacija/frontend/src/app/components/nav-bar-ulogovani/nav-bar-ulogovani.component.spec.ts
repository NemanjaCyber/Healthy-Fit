import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBarUlogovaniComponent } from './nav-bar-ulogovani.component';

describe('NavBarUlogovaniComponent', () => {
  let component: NavBarUlogovaniComponent;
  let fixture: ComponentFixture<NavBarUlogovaniComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavBarUlogovaniComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavBarUlogovaniComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
