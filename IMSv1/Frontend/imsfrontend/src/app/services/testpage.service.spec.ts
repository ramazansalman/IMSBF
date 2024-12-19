import { TestBed } from '@angular/core/testing';

import { TestpageService } from './testpage.service';

describe('TestpageService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TestpageService = TestBed.get(TestpageService);
    expect(service).toBeTruthy();
  });
});
