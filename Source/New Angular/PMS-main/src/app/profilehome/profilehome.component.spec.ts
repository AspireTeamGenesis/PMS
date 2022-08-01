import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfilehomeComponent } from './profilehome.component';

describe('ProfilehomeComponent', () => {
  let component: ProfilehomeComponent;
  let fixture: ComponentFixture<ProfilehomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfilehomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfilehomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
