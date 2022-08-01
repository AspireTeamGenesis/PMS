import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedprofileComponent } from './approvedprofile.component';

describe('ApprovedprofileComponent', () => {
  let component: ApprovedprofileComponent;
  let fixture: ComponentFixture<ApprovedprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApprovedprofileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApprovedprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
