import { TestBed } from '@angular/core/testing';
import { ConsultaFechas } from './consulta-fechas';

describe('ConsultaFechas', () => {
  let service: ConsultaFechas;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConsultaFechas);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
