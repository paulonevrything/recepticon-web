import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin/admin.component';
import { SharedModule } from '../shared/shared.module';
import { RoomListComponent } from './room-list/room-list.component';
import { UserListComponent } from './user-list/user-list.component';


@NgModule({
  declarations: [AdminComponent, UserListComponent, RoomListComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ]
})
export class AdminModule { }
