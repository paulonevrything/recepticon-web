import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Room } from 'src/app/core/interfaces/room';
import { RoomService } from 'src/app/core/services/room.service';
import { AddNewRoomTypeComponent } from '../components/add-new-room-type/add-new-room-type.component';
import { AddNewRoomComponent } from '../components/add-new-room/add-new-room.component';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.css']
})
export class RoomListComponent implements OnInit {

  constructor(public dialog: MatDialog, private roomService: RoomService) { }

  ngOnInit(): void {
    this.getAllRooms();
  }

  displayedColumns: string[] = ['roomNumber', 'roomTypeId', 'roomStatus', 'action'];
  dataSource: Room[] = [];

  @ViewChild(MatTable)
  table!: MatTable<Room>;

  addRoom() {
    let dialogRef = this.dialog.open(AddNewRoomComponent);

    dialogRef.afterClosed().subscribe(result => {
      this.getAllRooms();
    });
  }

  addRoomType() {
    this.dialog.open(AddNewRoomTypeComponent);
  }

  getAllRooms() {
    this.roomService.getAllRooms().subscribe(data => {
      console.log(data);
      this.dataSource = data;
    },
      err => {

      });
  }

}