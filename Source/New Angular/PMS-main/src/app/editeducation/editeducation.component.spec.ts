import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditeducationComponent } from './editeducation.component';

describe('EditeducationComponent', () => {
  let component: EditeducationComponent;
  let fixture: ComponentFixture<EditeducationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditeducationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditeducationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
