import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Guest } from 'src/app/core/interfaces/guest';
import { GuestService } from 'src/app/core/services/guest.service';
import { NewBookingComponent } from '../new-booking/new-booking.component';

@Component({
  selector: 'app-guest-list',
  templateUrl: './guest-list.component.html',
  styleUrls: ['./guest-list.component.css']
})
export class GuestListComponent implements OnInit {

  
  displayedColumns: string[] = ['firstName', 'lastName', 'phoneNumber', 'address', 'roomId', 'checkIn', 'checkOut'];
  guestList: Guest[] = [];
  dataSource!: MatTableDataSource<Guest>;

  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  @ViewChild(MatSort) sort: MatSort | undefined;

  constructor(private service: GuestService, private _snackBar: MatSnackBar,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.getGuests();
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getGuests() {
    this.service.getGuestList().subscribe(data => {
      console.log('guests: ', data);
      this.guestList = data;
      this.dataSource = new MatTableDataSource(this.guestList);
    },
      err => {
        console.log(err)
      });
  }

  bookGuest() {
    let dialogRef = this.dialog.open(NewBookingComponent);

    dialogRef.afterClosed().subscribe(()=> {
      this.getGuests();
    })
  }

}