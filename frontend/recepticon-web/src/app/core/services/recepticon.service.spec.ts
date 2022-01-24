import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { RecepticonService } from './recepticon.service';

describe('RecepticonService', () => {
  let service: RecepticonService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],});
    service = TestBed.inject(RecepticonService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
