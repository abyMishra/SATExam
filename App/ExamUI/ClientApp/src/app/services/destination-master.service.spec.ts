import { TestBed } from '@angular/core/testing';

import { DestinationMasterService } from './destination-master.service';

describe('DestinationMasterService', () => {
  let service: DestinationMasterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DestinationMasterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
