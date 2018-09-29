import { TestBed } from '@angular/core/testing';

import { LessonPlansService } from './lesson-plans.service';

describe('LessonPlansService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LessonPlansService = TestBed.get(LessonPlansService);
    expect(service).toBeTruthy();
  });
});
