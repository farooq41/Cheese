import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditCheeseComponent } from './edit-cheese.component';

describe('EditCheeseComponent', () => {
  let component: EditCheeseComponent;
  let fixture: ComponentFixture<EditCheeseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditCheeseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditCheeseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
