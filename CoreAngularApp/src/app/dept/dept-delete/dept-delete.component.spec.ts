import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeptDeleteComponent } from './dept-delete.component';

describe('DeptDeleteComponent', () => {
  let component: DeptDeleteComponent;
  let fixture: ComponentFixture<DeptDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeptDeleteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeptDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
