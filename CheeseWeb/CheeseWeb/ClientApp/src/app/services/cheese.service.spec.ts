import { TestBed, inject } from '@angular/core/testing';

import { CheeseService } from './cheese.service';

describe('CheeseService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CheeseService]
    });
  });

  it('should be created', inject([CheeseService], (service: CheeseService) => {
    expect(service).toBeTruthy();
  }));
});
