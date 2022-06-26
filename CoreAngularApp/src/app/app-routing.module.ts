import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DeptListComponent } from './dept/dept-list/dept-list.component';
import { DeptAddComponent } from './dept/dept-add/dept-add.component';
import { DeptEditComponent } from './dept/dept-edit/dept-edit.component';
import { DeptDeleteComponent } from './dept/dept-delete/dept-delete.component';


const routes: Routes = [
  { path: 'deptAdd', component: DeptAddComponent },
  { path: 'deptList', children : [
    { path: '',component: DeptListComponent },
    { path: 'deptEdit/:id',component: DeptEditComponent },
    { path: 'deptDelete/:id',component: DeptDeleteComponent }
  ]},
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule, RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
