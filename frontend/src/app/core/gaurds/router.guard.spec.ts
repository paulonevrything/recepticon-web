import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { RouterGuard } from './router.guard';

describe('RouterGuard', () => {
  let guard: RouterGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
    });
    guard = TestBed.inject(RouterGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
