import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyFullComponent } from './body-full.component';

describe('BodyFullComponent', () => {
  let component: BodyFullComponent;
  let fixture: ComponentFixture<BodyFullComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BodyFullComponent]
    });
    fixture = TestBed.createComponent(BodyFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
