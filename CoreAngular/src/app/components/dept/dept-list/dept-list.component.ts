import { Component, OnInit } from '@angular/core';
import { DeptService } from '../../../services/dept-services/dept.service';


@Component({
  selector: 'app-dept-list',
  templateUrl: './dept-list.component.html',
  styleUrls: ['./dept-list.component.css']
})
export class DeptListComponent implements OnInit {

  deptList: any;

  constructor(private service: DeptService) { }

  ngOnInit(): void {

    this.service.listDepts().then(data => {
      this.deptList = data;
      this.deptList = this.deptList.model;
      //console.log(data);
    }, error => console.log(error));

  }

}
