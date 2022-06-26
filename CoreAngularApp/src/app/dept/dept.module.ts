import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeptListComponent } from './dept-list/dept-list.component';
import { DeptAddComponent } from './dept-add/dept-add.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DeptEditComponent } from './dept-edit/dept-edit.component';
import { DeptDeleteComponent } from './dept-delete/dept-delete.component';



@NgModule({
  declarations: [
    DeptListComponent,
    DeptAddComponent,
    DeptEditComponent,
    DeptDeleteComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ]
})
export class DeptModule { }
