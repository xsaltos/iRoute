import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ConsultaFechasService } from '../../services/consulta-fechas';

@Component({
  selector: 'app-consulta-fechas',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './consulta-fechas.html'
})
export class ConsultaFechas {

  fecha: string = '';

  registros: any[] = [];

  constructor(
    private consultaFechasService: ConsultaFechasService
  ) { }

  consultar(): void {

    if (!this.fecha) {
      alert('Seleccione una fecha');
      return;
    }

    this.consultaFechasService
      .consultar(this.fecha)
      .subscribe({
        next: (resp: any) => {

          console.log(resp);

          this.registros = resp;
        },
        error: (err: any) => {
          console.log('STATUS ', err.status);
          console.log('error ', err.error);
          console.log('completo ', err);
          console.error(err);

          alert('Error al consultar');
          //debugger;
        }
      });
  }
}
