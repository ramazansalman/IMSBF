import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ImmovableComponent } from './immovable.component';

describe('ImmovableComponent', () => {
  let component: ImmovableComponent;
  let fixture: ComponentFixture<ImmovableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ImmovableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ImmovableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
