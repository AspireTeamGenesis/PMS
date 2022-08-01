import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WaitingprofileComponent } from './waitingprofile.component';

describe('WaitingprofileComponent', () => {
  let component: WaitingprofileComponent;
  let fixture: ComponentFixture<WaitingprofileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WaitingprofileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WaitingprofileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
