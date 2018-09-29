import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LessonPlan } from '../models/lesson-plan';

@Injectable({
  providedIn: 'root'
})
export class LessonPlansService {

  constructor(private http: HttpClient) { }

  getLessonPlans(): Observable<LessonPlan[]> {
    return this.http.get<LessonPlan[]>('http://localhost:5000/api/LessonPlans');
  }

  getLessonPlan(lessonPlanId: string): Observable<LessonPlan> {
    // Add safe, URL encoded search parameter if there is a search term
    // const options = { params: new HttpParams().set('studentId', studentId) };

    return this.http.get<LessonPlan>('http://localhost:5000/api/LessonPlans/' + lessonPlanId);
  }
}
