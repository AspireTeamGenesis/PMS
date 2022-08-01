import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HrsearchComponent } from './hrsearch.component';

describe('HrsearchComponent', () => {
  let component: HrsearchComponent;
  let fixture: ComponentFixture<HrsearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HrsearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HrsearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
