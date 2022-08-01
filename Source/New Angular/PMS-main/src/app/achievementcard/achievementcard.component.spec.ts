import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AchievementcardComponent } from './achievementcard.component';

describe('AchievementcardComponent', () => {
  let component: AchievementcardComponent;
  let fixture: ComponentFixture<AchievementcardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AchievementcardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AchievementcardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
