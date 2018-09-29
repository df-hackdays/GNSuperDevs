import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lesson } from '../models/lesson';

@Injectable({
  providedIn: 'root'
})
export class LessonsService {

  constructor(private http: HttpClient) { }

  getLessons(): Observable<Lesson[]> {
    return this.http.get<Lesson[]>('http://localhost:5000/api/Lessons');
  }

  getLesson(lessonId: string): Observable<Lesson> {
    // Add safe, URL encoded search parameter if there is a search term
    // const options = { params: new HttpParams().set('studentId', studentId) };

    return this.http.get<Lesson>('http://localhost:5000/api/Lessons/' + lessonId);
  }

  getRecommendedLessons(studentId: string, limit: number): Observable<Lesson[]> {
    const options = { params: new HttpParams().set('recommendedOnly', 'true').set('studentId', studentId).set('limit', limit.toString()) };

    return this.http.get<Lesson[]>('http://localhost:5000/api/Lessons/', options);
  }
}
