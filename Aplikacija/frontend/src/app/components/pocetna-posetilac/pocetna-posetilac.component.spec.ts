import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PocetnaPosetilacComponent } from './pocetna-posetilac.component';

describe('PocetnaPosetilacComponent', () => {
  let component: PocetnaPosetilacComponent;
  let fixture: ComponentFixture<PocetnaPosetilacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PocetnaPosetilacComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PocetnaPosetilacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
