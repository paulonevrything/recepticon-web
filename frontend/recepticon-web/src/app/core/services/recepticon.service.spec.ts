import { TestBed } from '@angular/core/testing';

import { RecepticonService } from './recepticon.service';

describe('RecepticonService', () => {
  let service: RecepticonService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RecepticonService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
