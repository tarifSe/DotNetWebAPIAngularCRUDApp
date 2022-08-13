import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { StudentDetail } from 'src/app/shared/student-detail.model';
import { StudentDetailService } from 'src/app/shared/student-detail.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-student-detail-form',
  templateUrl: './student-detail-form.component.html'
})
export class StudentDetailFormComponent implements OnInit {

  constructor(public service:StudentDetailService,private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    if(this.service.formData.id == 0)
      this.addStudent(form);
    else
      this.updateStudent(form);
  }

  addStudent(form: NgForm){
    this.service.postStudentDetail().subscribe(
      res => {
        this.restForm(form);
        this.service.getList();
        this.toastr.success('Student ditails saved.','Submitted succesfully!')
      },
      err => {
        console.log(err);
      }
    );
  }

  updateStudent(form: NgForm){
    this.service.editStudentDetail().subscribe(
      res => {
        this.restForm(form);
        this.service.getList();
        this.toastr.info('Student ditails updated.','Submitted succesfully!')
      },
      err => {
        console.log(err);
      }
    );
  }

  restForm(form: NgForm){
    form.form.reset();
    this.service.formData = new StudentDetail();
  }
}
