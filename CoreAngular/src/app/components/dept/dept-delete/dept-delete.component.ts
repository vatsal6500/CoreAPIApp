import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DeptService } from '../../../services/dept-services/dept.service';

@Component({
  selector: 'app-dept-delete',
  templateUrl: './dept-delete.component.html',
  styleUrls: ['./dept-delete.component.css']
})
export class DeptDeleteComponent implements OnInit {

  deptId:any;



  constructor(private activatedRouter:ActivatedRoute,
    private services:DeptService,
    private router:Router) { }

  ngOnInit(): void {

    this.activatedRouter.params.subscribe(data => {
      this.deptId = data['id'];
    })

    if(this.deptId){
      if(confirm('Are you sure?')){
        this.services.deleteDept(this.deptId).then(data => {
          this.router.navigate(['deptList']);
        }, err => console.log(err))
      }
    }
    else{
      this.router.navigate(['deptList']);
    }

  }

}
