import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { LessonsService } from '../services/lessons.service';
import { Lesson } from '../models/lesson';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.css']
})
export class LessonComponent implements OnInit {
  public lesson = new Lesson('', '', '', '', '');
  public i = 1;
  public left = '';
  public right = '';
  public leftHtmls = [
    '<p>Step 1: The required information from the user and the device will be entered to the program manually. ' +
    'This information is passed to the corresponding variables as "string" type.</p>',
    '<p>Step 1: The required information from the user and the device will be entered to the program manually. ' +
    'This information is passed to the corresponding variables as "string" type.</p>',
    '<p>Step 2: Using the predefined class "ConnectHandler" and the data from the previous input, ' +
    'login in to the network device at the "exec" mode and disconnect from it.</p>',
    '<p>Step 2: Using the predefined class "ConnectHandler" and the data from the previous input, ' +
    'login in to the network device at the "exec" mode and disconnect from it.</p>',
    '<p>Step 3: In order to validate the login action was successful, the device prompt is ' +
    'retrieved and displayed for verification purposes.</p>',
    '<p>Step 3: In order to validate the login action was successful, the device prompt is ' +
    'retrieved and displayed for verification purposes.</p>'
  ];
  public rightHtmls = [
    '',
    '<img class="mr-3" src="../../assets/images/py1.png">',
    '',
    '<img class="mr-3" src="../../assets/images/py2.png">',
    '',
    '<img class="mr-3" src="../../assets/images/py3.png">',
  ];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private lessonsService: LessonsService
  ) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.lessonsService.getLesson(params.get('lessonId')))
    )
    .subscribe(l => this.lesson = l);

    for (let i = 0; i < this.leftHtmls.length; i++) {
      setTimeout(() => {
        this.left = this.leftHtmls[i];
        this.right = this.rightHtmls[i];
      }, 5000);
    }
  }
}
