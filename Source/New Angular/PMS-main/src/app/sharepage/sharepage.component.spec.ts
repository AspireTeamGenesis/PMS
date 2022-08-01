import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharepageComponent } from './sharepage.component';

describe('SharepageComponent', () => {
  let component: SharepageComponent;
  let fixture: ComponentFixture<SharepageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SharepageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SharepageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
