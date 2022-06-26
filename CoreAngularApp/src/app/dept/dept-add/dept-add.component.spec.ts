import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeptAddComponent } from './dept-add.component';

describe('DeptAddComponent', () => {
  let component: DeptAddComponent;
  let fixture: ComponentFixture<DeptAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeptAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeptAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
