import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HrchangepasswordComponent } from './hrchangepassword.component';

describe('HrchangepasswordComponent', () => {
  let component: HrchangepasswordComponent;
  let fixture: ComponentFixture<HrchangepasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HrchangepasswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HrchangepasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
