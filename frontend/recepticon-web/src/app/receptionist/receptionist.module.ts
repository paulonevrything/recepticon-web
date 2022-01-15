import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReceptionistRoutingModule } from './receptionist-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ReceptionistComponent } from './receptionist/receptionist.component';


@NgModule({
  declarations: [ReceptionistComponent],
  imports: [
    CommonModule,
    ReceptionistRoutingModule,
    SharedModule
  ]
})
export class ReceptionistModule { }
