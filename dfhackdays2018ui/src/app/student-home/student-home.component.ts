import { Component, OnInit } from '@angular/core';
import { StudentsService } from '../services/students.service';
import { Student } from '../models/student';

@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.css']
})
export class StudentHomeComponent implements OnInit {
  public currentStudent = new Student('', '', '', '', null, '', '', [], null);

  constructor(private studentsService: StudentsService) { }

  ngOnInit() {
    if (!localStorage.getItem('studentId')) {
      // redirect to sign in
    }

    this.studentsService
      .getStudent(localStorage.getItem('studentId'))
      .subscribe(stu => this.currentStudent = stu);
  }

}
