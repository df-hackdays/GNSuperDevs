import { Component, OnInit } from '@angular/core';
import { StudentsService } from '../services/students.service';
import { Student } from '../models/student';
import { LessonsService } from '../services/lessons.service';
import { Lesson } from '../models/lesson';

@Component({
  selector: 'app-student-home',
  templateUrl: './student-home.component.html',
  styleUrls: ['./student-home.component.css']
})
export class StudentHomeComponent implements OnInit {
  public currentStudent = new Student('', '', '', '', null, '', '', [], null);
  public recommendedLessons = Array.of<Lesson>();

  constructor(
    private studentsService: StudentsService,
    private lessonsService: LessonsService
    ) { }

  ngOnInit() {
    if (!localStorage.getItem('studentId')) {
      // redirect to sign in
    }

    this.studentsService
      .getStudent(localStorage.getItem('studentId'))
      .subscribe(stu => this.currentStudent = stu);

    this.lessonsService
      .getRecommendedLessons(localStorage.getItem('studentId'), 3)
      .subscribe(l => this.recommendedLessons = l);
  }

}
