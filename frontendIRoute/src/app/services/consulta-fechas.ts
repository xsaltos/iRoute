import { Service } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable(
  {
  providedIn: 'root'
  }
)
export class ConsultaFechasService {

  constructor(
    private http: HttpClient
  ) { }

  consultar(fecha: string) {
    alert(fecha);
   // const fechaProceso = new Date(fecha);
   // alert(fecha);
    return this.http.get(
      `https://localhost:7022/api/CargaCsv/consultar/${fecha}`

    );
  }
}
