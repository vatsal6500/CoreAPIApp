import { HttpClient } from '@angular/common/http';
import { SERVER_URL } from '../../environments/environment'
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DeptService {

  constructor(private http: HttpClient) { }

  listDepts() {

    let method = "department/all";

    return new Promise((resolve,reject) => {
      this.http.get(SERVER_URL + method).subscribe({
        next : (res) => {
          resolve(res);
        },
        error : (err) => {
          reject(err);
        }
      })
    });
  }

  viewDept(id: string) {

    let method = "department/";

    return new Promise((resolve, reject) => {
      this.http.get(SERVER_URL + method + id).subscribe({
        next : (res) => {
          resolve(res);
        },
        error : (err) => {
          reject(err);
        }
      })
    });
  }

  addDept(deptObj: any) {

    let method = "department";

    return new Promise((resolve,reject) => {
      this.http.post(SERVER_URL + method, deptObj).subscribe({
        next : (res) => {
          resolve(res);
        },
        error : (err) => {
          reject(err);
        }
      })
    });
  }
  
  updateDept(id: string, deptObj: any) {

    let method = "department/"

    return new Promise((resolve, reject) => {
      this.http.put(SERVER_URL + method + id, deptObj).subscribe({
        next : (res) => {
          resolve(res);
        },
        error : (err) => {
          reject(err);
        }
      })
    });
  }

  deleteDept(id: string) {

    let method = "department/"

    return new Promise((resolve, reject) => {
      this.http.delete(SERVER_URL + method + id).subscribe({
        next : (res) => {
          resolve(res);
        },
        error : (err) => {
          reject(err);
        }
      })
    });
  }

}
