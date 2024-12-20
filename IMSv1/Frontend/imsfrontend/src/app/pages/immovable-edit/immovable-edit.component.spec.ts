import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImmovableEditComponent } from './immovable-edit.component';

describe('ImmovableEditComponent', () => {
  let component: ImmovableEditComponent;
  let fixture: ComponentFixture<ImmovableEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImmovableEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImmovableEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
