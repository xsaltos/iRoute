import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CargaCsvService {

  constructor(private http: HttpClient) { }

  guardar(archivo: File) {

    const formData = new FormData();

    formData.append('archivo', archivo);

    return this.http.post(
      'https://localhost:7022/api/CargaCsv/cargaArchivo',
      formData
    );
  }



}
