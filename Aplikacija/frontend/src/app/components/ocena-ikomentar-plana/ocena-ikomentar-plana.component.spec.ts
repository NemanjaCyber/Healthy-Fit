import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OcenaIKomentarPlanaComponent } from './ocena-ikomentar-plana.component';

describe('OcenaIKomentarPlanaComponent', () => {
  let component: OcenaIKomentarPlanaComponent;
  let fixture: ComponentFixture<OcenaIKomentarPlanaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OcenaIKomentarPlanaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OcenaIKomentarPlanaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
