import { Routes } from '@angular/router';

import { Home } from './pages/home/home';
import { CargaCsv } from './pages/carga-csv/carga-csv';
import { ConsultaFechas } from './pages/consulta-fechas/consulta-fechas';
import { Errores } from './pages/errores/errores';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'carga-csv', component: CargaCsv },
  { path: 'consulta-fecha', component: ConsultaFechas },
  { path: 'errores', component: Errores }
];
