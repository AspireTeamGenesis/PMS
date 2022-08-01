import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalprofileComponent } from './totalprofile.component';

describe('TotalprofileComponent', () => {
  let component: TotalprofileComponent;
  let fixture: ComponentFixture<TotalprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TotalprofileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
