import { TestBed } from '@angular/core/testing';

import { JugueteService } from './juguete.service';

describe('JugueteService', () => {
  let service: JugueteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JugueteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
