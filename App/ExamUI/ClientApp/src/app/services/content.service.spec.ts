import { TestBed } from '@angular/core/testing';

import { ContentService } from './content.service';

describe('IdentityService', () => {
  let service: ContentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
