import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclinedprofileComponent } from './declinedprofile.component';

describe('DeclinedprofileComponent', () => {
  let component: DeclinedprofileComponent;
  let fixture: ComponentFixture<DeclinedprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeclinedprofileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeclinedprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
