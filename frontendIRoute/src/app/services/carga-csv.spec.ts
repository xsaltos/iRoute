import { TestBed } from '@angular/core/testing';
import { CargaCsv } from './carga-csv';

describe('CargaCsv', () => {
  let service: CargaCsv;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CargaCsv);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
