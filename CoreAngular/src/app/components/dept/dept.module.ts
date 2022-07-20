import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeptAddComponent } from './dept-add/dept-add.component';
import { DeptDeleteComponent } from './dept-delete/dept-delete.component';
import { DeptListComponent } from './dept-list/dept-list.component';
import { DeptEditComponent } from './dept-edit/dept-edit.component';



@NgModule({
  declarations: [
    DeptAddComponent,
    DeptDeleteComponent,
    DeptListComponent,
    DeptEditComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DeptModule { }
