import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FAccComponent } from './facc.component';

describe('FAccComponent', () => {
  let component: FAccComponent;
  let fixture: ComponentFixture<FAccComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FAccComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FAccComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
