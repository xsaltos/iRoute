import { Component } from '@angular/core';
import { CargaCsvService } from '../../services/carga-csv';

@Component({
  selector: 'app-carga-csv',
  templateUrl: './carga-csv.html'
})
export class CargaCsv {

  archivoSeleccionado!: File;

  datos: any[] = [];
  columnas: string[] = [];

  constructor(
    private cargaCsvService: CargaCsvService
  ) { }

  seleccionarArchivo(event: Event): void {

    const input = event.target as HTMLInputElement;

    if (!input.files || input.files.length === 0) {
      return;
    }

    this.archivoSeleccionado = input.files[0];

    const reader = new FileReader();

    reader.onload = (e: any) => {

      const contenido = e.target.result;

      const lineas = contenido
        .split(/\r?\n/)
        .filter((l: string) => l.trim() !== '');

      if (lineas.length === 0) {
        return;
      }

      this.columnas = lineas[0]
        .split(';')
        .map((c: string) => c.trim());

      this.datos = lineas
        .slice(1)
        .map((linea: string) => {

          const valores = linea.split(';');

          const fila: any = {};

          this.columnas.forEach((columna, index) => {
            fila[columna] = valores[index]?.trim() ?? '';
          });

          return fila;
        });

      console.log('Columnas:', this.columnas);
      console.log('Datos:', this.datos);
    };

    reader.readAsText(this.archivoSeleccionado);
  }

  enviarArchivo(): void {

    if (!this.archivoSeleccionado) {
      alert('Seleccione un archivo');
      return;
    }

    this.cargaCsvService
      .guardar(this.archivoSeleccionado)
      .subscribe({
        next: (resp: any) => {
          console.log(resp);
          alert('Archivo procesado correctamente');
        },
        error: (err: any) => {
          console.error("este es el error " + err.error + " " +err.status);
          alert('Error al enviar archivo');
        }
      });
  }
}
