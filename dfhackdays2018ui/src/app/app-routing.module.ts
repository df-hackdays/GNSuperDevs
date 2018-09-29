import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignUpComponent } from './sign-up/sign-up.component';
import { StudentHomeComponent } from './student-home/student-home.component';
import { LessonComponent } from './lesson/lesson.component';

const routes: Routes = [
  {
    path: 'sign-up',
    component: SignUpComponent
  },
  {
    path: 'student/home',
    component: StudentHomeComponent
  },
  {
    path: 'lesson/:lessonId',
    component: LessonComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
