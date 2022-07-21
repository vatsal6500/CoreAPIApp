import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DeptService } from '../../../services/dept-services/dept.service';


@Component({
  selector: 'app-dept-edit',
  templateUrl: './dept-edit.component.html',
  styleUrls: ['./dept-edit.component.css']
})
export class DeptEditComponent implements OnInit {

  deptId:any;
  deptDetails:any;
  editDeptForm:FormGroup = new FormGroup({});
  dataLoaded:boolean = false


  constructor(private activatedrouter:ActivatedRoute,
    private services:DeptService,
    private formbuilder:FormBuilder,
    private router:Router) { }

  ngOnInit(): void {
    this.activatedrouter.params.subscribe(data => {
      this.deptId = data['id'];
    })

    if(this.deptId){
      this.dataLoaded = false
      this.services.viewDept(this.deptId)
      .then(data => {
        this.deptDetails = data;
        console.log(this.deptDetails);
        this.editDeptForm = this.formbuilder.group({
          'DeptName':new FormControl(this.deptDetails.deptname),
          'DeptId' : this.deptId
        })
        this.dataLoaded = true
      })
      .catch(err => {
        console.log(err)
      })
    }

  }

  updateDept(){
    console.log(this.editDeptForm.value);
    this.services.updateDept(this.deptId,this.editDeptForm.value).then(data => {
      this.router.navigate(['deptList']);
    },error => console.log(error))
  }

}

