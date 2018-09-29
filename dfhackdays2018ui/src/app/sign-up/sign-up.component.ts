import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StudentsService } from '../services/students.service';
import { Student } from '../models/student';
import { Observable } from 'rxjs';
import { Profession } from '../models/profession';
import { ProfessionsService } from '../services/professions.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  public submitted = false;
  public newStudent = new Student('', '', '', '', null, '', '', [], null);

  public professions: Profession[];

  constructor(private studentsService: StudentsService,
    private professionsService: ProfessionsService,
    private router: Router) { }

  ngOnInit() {
    this.professionsService.getProfessions().subscribe(profs => this.professions = profs);
  }

  onSubmit() {
    this.newStudent.signUpDate = new Date();
    this.studentsService.addStudent(this.newStudent).subscribe(stud => {
      this.submitted = true;
      localStorage.setItem('studentId', stud.studentId);
      console.log(stud.studentId);
      this.router.navigate(['/student/home']);
    });
  }
}
