import { Injectable } from '@angular/core';
import { StudentDetail } from './student-detail.model';
import { HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class StudentDetailService {

  constructor(private http:HttpClient) { } 

  readonly baseURL='https://localhost:44337/api/Student/Save'
  readonly editDeleteURL='https://localhost:44337/api/Student'
  readonly getListURL='https://localhost:44337/api/Student/GetStudents'
  formData: StudentDetail = new StudentDetail();
  list : StudentDetail[];

  postStudentDetail(){
    return this.http.post(this.baseURL, this.formData);
  }

  editStudentDetail(){
    return this.http.put(`${this.editDeleteURL}/${this.formData.id}`, this.formData);
  }

  deleteStudentDetail(id:number){
    return this.http.delete(`${this.editDeleteURL}/${id}`);
  }

  getList(){
    this.http.get(this.getListURL)
    .toPromise()
    .then(res => this.list = res as StudentDetail[]);
  }

}
