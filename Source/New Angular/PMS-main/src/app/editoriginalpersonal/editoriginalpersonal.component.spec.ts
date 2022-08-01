import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditoriginalpersonalComponent } from './editoriginalpersonal.component';

describe('EditoriginalpersonalComponent', () => {
  let component: EditoriginalpersonalComponent;
  let fixture: ComponentFixture<EditoriginalpersonalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditoriginalpersonalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditoriginalpersonalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
