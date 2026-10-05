import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CargaCsv } from './carga-csv';

describe('CargaCsv', () => {
  let component: CargaCsv;
  let fixture: ComponentFixture<CargaCsv>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CargaCsv],
    }).compileComponents();

    fixture = TestBed.createComponent(CargaCsv);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
