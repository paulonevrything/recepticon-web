import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin/admin.component';
import { SharedModule } from '../shared/shared.module';
import { RoomListComponent } from './room-list/room-list.component';
import { UserListComponent } from './user-list/user-list.component';
import { AddNewUserComponent } from './add-new-user/add-new-user.component';
import { AddNewRoomComponent } from './add-new-room/add-new-room.component';
import { AddNewRoomTypeComponent } from './add-new-room-type/add-new-room-type.component';


@NgModule({
  declarations: [AdminComponent, UserListComponent, RoomListComponent, AddNewUserComponent, AddNewRoomComponent, AddNewRoomTypeComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule
  ]
})
export class AdminModule { }
