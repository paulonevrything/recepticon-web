import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () => import('../../src/app/admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'receptionist',
    loadChildren: () => import('../../src/app/receptionist/receptionist.module').then(m => m.ReceptionistModule)
  },
  {
    path: 'auth',
    loadChildren: () => import('../../src/app/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '',
    redirectTo: 'auth',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
