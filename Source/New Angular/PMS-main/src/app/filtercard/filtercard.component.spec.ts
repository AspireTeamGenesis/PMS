import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltercardComponent } from './filtercard.component';

describe('FiltercardComponent', () => {
  let component: FiltercardComponent;
  let fixture: ComponentFixture<FiltercardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FiltercardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltercardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
