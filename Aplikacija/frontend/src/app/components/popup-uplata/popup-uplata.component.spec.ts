import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopupUplataComponent } from './popup-uplata.component';

describe('PopupUplataComponent', () => {
  let component: PopupUplataComponent;
  let fixture: ComponentFixture<PopupUplataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PopupUplataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PopupUplataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
