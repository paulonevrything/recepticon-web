import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReceptionistComponent } from './receptionist/receptionist.component';

const routes: Routes = [
  {
    path: '',
    component: ReceptionistComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ReceptionistRoutingModule { }
