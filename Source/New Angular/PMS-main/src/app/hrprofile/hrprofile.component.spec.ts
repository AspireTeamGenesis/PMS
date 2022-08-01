import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HrprofileComponent } from './hrprofile.component';

describe('HrprofileComponent', () => {
  let component: HrprofileComponent;
  let fixture: ComponentFixture<HrprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HrprofileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HrprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
