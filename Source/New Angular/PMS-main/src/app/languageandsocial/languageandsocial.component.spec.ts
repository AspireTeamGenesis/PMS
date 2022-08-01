import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LanguageandsocialComponent } from './languageandsocial.component';

describe('LanguageandsocialComponent', () => {
  let component: LanguageandsocialComponent;
  let fixture: ComponentFixture<LanguageandsocialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LanguageandsocialComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LanguageandsocialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
