import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EducationcardComponent } from './educationcard.component';

describe('EducationcardComponent', () => {
  let component: EducationcardComponent;
  let fixture: ComponentFixture<EducationcardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EducationcardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EducationcardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
