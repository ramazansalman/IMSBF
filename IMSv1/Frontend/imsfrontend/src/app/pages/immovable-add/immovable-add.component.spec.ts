import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImmovableAddComponent } from './immovable-add.component';

describe('ImmovableAddComponent', () => {
  let component: ImmovableAddComponent;
  let fixture: ComponentFixture<ImmovableAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImmovableAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImmovableAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
