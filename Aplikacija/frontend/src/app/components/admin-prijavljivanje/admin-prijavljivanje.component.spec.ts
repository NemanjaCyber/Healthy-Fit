import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPrijavljivanjeComponent } from './admin-prijavljivanje.component';

describe('AdminPrijavljivanjeComponent', () => {
  let component: AdminPrijavljivanjeComponent;
  let fixture: ComponentFixture<AdminPrijavljivanjeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminPrijavljivanjeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminPrijavljivanjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
