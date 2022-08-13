import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { StudentDetail } from '../shared/student-detail.model';
import { StudentDetailService } from '../shared/student-detail.service';
import { ToastrService } from 'ngx-toastr';
import {jsPDF} from 'jspdf';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html'
})
export class StudentDetailsComponent implements OnInit {

  constructor(public service : StudentDetailService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.getList();
  }

  populateForm(selectedRecord : StudentDetail){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if(confirm("Are you sure you want to delete this?")){
      this.service.deleteStudentDetail(id).subscribe(
        res => {
          this.service.getList();
          this.toastr.error('Student has been deleted.','Submitted succesfully!')
        },
        err => {
          console.log(err);
        }
      );
    }
  }

  @ViewChild('content', {static:false}) el!: ElementRef;
  SavePDF(){
    let pdf=new jsPDF('p','pt','a4');
    pdf.html(this.el.nativeElement,{
      callback: (pdf)=>{
        pdf.save('MyStudentRecords_Pdf');
      }
    });
  }



  SaveExcel(): void
  {
    /* pass here the table id */
    let element = document.getElementById('content');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);
 
    /* generate workbook and add the worksheet */
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
 
    /* save to file */  
    XLSX.writeFile(wb,"MyExcelSheet.xlsx");
  }

}
