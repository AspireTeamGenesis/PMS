import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HrsidebarComponent } from './hrsidebar.component';

describe('HrsidebarComponent', () => {
  let component: HrsidebarComponent;
  let fixture: ComponentFixture<HrsidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HrsidebarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HrsidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
