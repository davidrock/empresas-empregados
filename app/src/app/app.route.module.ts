import { RouterModule, Routes } from '@angular/router';
import { EmpresaComponent } from './pages/empresa/empresa.component';

const appRoutes: Routes = [
    { path: '', component: EmpresaComponent },
    {
      path: '**',
      redirectTo: 'empresa',
      pathMatch: 'full'
    },
    // { path: '**', component: PageNotFoundComponent }
  ];