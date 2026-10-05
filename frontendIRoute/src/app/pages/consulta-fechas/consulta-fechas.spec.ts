import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ConsultaFechas } from './consulta-fechas';

describe('ConsultaFechas', () => {

  let component: ConsultaFechas;
  let fixture: ComponentFixture<ConsultaFechas>;

  beforeEach(async () => {

    await TestBed.configureTestingModule({
      imports: [ConsultaFechas]
    }).compileComponents();

    fixture = TestBed.createComponent(ConsultaFechas);
    component = fixture.componentInstance;

    fixture.detectChanges();
  });

  it('should create', () => {

    expect(component).toBeTruthy();
  });
})
