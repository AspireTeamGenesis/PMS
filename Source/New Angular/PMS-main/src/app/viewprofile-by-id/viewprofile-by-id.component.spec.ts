import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewprofileByIdComponent } from './viewprofile-by-id.component';

describe('ViewprofileByIdComponent', () => {
  let component: ViewprofileByIdComponent;
  let fixture: ComponentFixture<ViewprofileByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewprofileByIdComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewprofileByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
