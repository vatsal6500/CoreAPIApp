import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DeptService } from '../../services/dept.service';

@Component({
  selector: 'app-dept-add',
  templateUrl: './dept-add.component.html',
  styleUrls: ['./dept-add.component.css']
})
export class DeptAddComponent implements OnInit {

  addDeptForm: FormGroup = new FormGroup({});

  deptData: any;

  constructor(private services: DeptService,
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {

    this.addDeptForm = this.formBuilder.group({
      'DeptName': new FormControl('')
    })

  }

  createDept() {
    this.services.addDept(this.addDeptForm.value).then(data => {
      this.router.navigate(['deptList']);
    }, error => console.log(error));
  }

}
