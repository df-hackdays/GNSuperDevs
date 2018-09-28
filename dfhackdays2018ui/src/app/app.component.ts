import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from './models/student';
import { Interest } from './models/interest';
import { StudentsService } from './services/students.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'dfhackdays2018ui';
  public student: Student;

  constructor(private studentsService: StudentsService) {
  }

  ngOnInit() {
    this.studentsService.getStudent('5bae7dd6b9c86c5461b48943').subscribe(stud => this.student = stud);
  }
}
