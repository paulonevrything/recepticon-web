import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Guest } from 'src/app/core/interfaces/guest';
import { GuestService } from 'src/app/core/services/guest.service';

@Component({
  selector: 'app-guest-list',
  templateUrl: './guest-list.component.html',
  styleUrls: ['./guest-list.component.css']
})
export class GuestListComponent implements OnInit {

  constructor(private service: GuestService, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  displayedColumns: string[] = ['firstName', 'lastName', 'phoneNumber', 'address', 'roomId', 'checkIn', 'checkOut'];
  guestList: Guest[] = [];

  dataSource = new MatTableDataSource(this.guestList);

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getGuests() {
    this.service.getGuestList().subscribe(data => {
      console.log(data);
      this.guestList = data;
    },
      err => {
        console.log(err)
        this._snackBar.open(err.error.message, 'Ok', {
          duration: 3000
        })
      });
  }

}