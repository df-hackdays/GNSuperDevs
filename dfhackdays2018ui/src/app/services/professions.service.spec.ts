import { TestBed } from '@angular/core/testing';

import { ProfessionsService } from './professions.service';

describe('ProfessionsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ProfessionsService = TestBed.get(ProfessionsService);
    expect(service).toBeTruthy();
  });
});
