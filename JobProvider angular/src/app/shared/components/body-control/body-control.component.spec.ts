import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BodyControlComponent } from './body-control.component';

describe('BodyControlComponent', () => {
  let component: BodyControlComponent;
  let fixture: ComponentFixture<BodyControlComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BodyControlComponent]
    });
    fixture = TestBed.createComponent(BodyControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
