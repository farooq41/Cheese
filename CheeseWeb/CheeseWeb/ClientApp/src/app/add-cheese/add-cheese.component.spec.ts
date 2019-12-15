import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCheeseComponent } from './add-cheese.component';

describe('AddCheeseComponent', () => {
  let component: AddCheeseComponent;
  let fixture: ComponentFixture<AddCheeseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCheeseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCheeseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
