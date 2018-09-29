import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Student } from '../models/student';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private http: HttpClient) { }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>('http://localhost:5000/api/Students');
  }

  getStudent(studentId: string): Observable<Student> {
    // Add safe, URL encoded search parameter if there is a search term
    // const options = { params: new HttpParams().set('studentId', studentId) };

    return this.http.get<Student>('http://localhost:5000/api/Students/' + studentId);
  }

  addStudent(newStudent: Student): Observable<Student> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    return this.http.post<Student>('http://localhost:5000/api/Students/', newStudent);
  }
}
