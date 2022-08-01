import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SnapbarComponent } from './snapbar.component';

describe('SnapbarComponent', () => {
  let component: SnapbarComponent;
  let fixture: ComponentFixture<SnapbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SnapbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SnapbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
