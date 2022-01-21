import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './core/gaurds/auth.guard';
import { RouterGuard } from './core/gaurds/router.guard';
import { Role } from './core/interfaces/role';

const routes: Routes = [
  {
    path: 'admin',
    loadChildren: () => import('../../src/app/admin/admin.module').then(m => m.AdminModule),
    canActivate: [RouterGuard],
    data: {
      role: Role.Admin
    }
  },
  {
    path: 'receptionist',
    loadChildren: () => import('../../src/app/receptionist/receptionist.module').then(m => m.ReceptionistModule),
    canActivate: [RouterGuard],
    data: {
      role: Role.Receptionist
    }
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
