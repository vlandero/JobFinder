import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SAccComponent } from './sacc.component';

describe('SAccComponent', () => {
  let component: SAccComponent;
  let fixture: ComponentFixture<SAccComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SAccComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SAccComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
