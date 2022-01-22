import { StepperSelectionEvent } from '@angular/cdk/stepper';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Guest } from 'src/app/core/interfaces/guest';
import { Room } from 'src/app/core/interfaces/room';
import { RoomType } from 'src/app/core/interfaces/roomType';
import { GuestService } from 'src/app/core/services/guest.service';
import { RoomService } from 'src/app/core/services/room.service';

@Component({
  selector: 'app-new-booking',
  templateUrl: './new-booking.component.html',
  styleUrls: ['./new-booking.component.css']
})
export class NewBookingComponent implements OnInit {

  newGuestFormGroup!: FormGroup;
  bookingInformationFormGroup!: FormGroup;
  showSpinner: boolean = false;
  roomTypes: RoomType[] = [];
  rooms: Room[] = [];
  roomsResult: Room[] = [];

  guest: any;

  reservation: any;

  todaysDate: Date = new Date();

  constructor(private fb: FormBuilder, private service: GuestService,
    private _snackBar: MatSnackBar, private roomService: RoomService) { }

  ngOnInit(): void {

    this.getRoomTypes();
    this.getRooms();
    this.buildForms();
  }

  buildForms() {

    this.newGuestFormGroup = this.fb.group({

      firstName: new FormControl('', Validators.compose([
        Validators.required
      ])),

      lastName: new FormControl('', Validators.compose([
        Validators.required
      ])),

      phoneNumber: new FormControl('', Validators.compose([
        Validators.required
      ])),

      address: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

    this.bookingInformationFormGroup = this.fb.group({

      roomType: new FormControl('', Validators.compose([
        Validators.required
      ])),

      roomNumber: new FormControl('', Validators.compose([
        Validators.required
      ])),

      checkInDate: new FormControl('', Validators.compose([
        Validators.required
      ])),

      checkOutDate: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

  }

  buildGuest() {

    let guest: Guest = {
      id: 0,
      firstName: this.newGuestFormGroup.controls.firstName.value,
      lastName: this.newGuestFormGroup.controls.lastName.value,
      phoneNumber: this.newGuestFormGroup.controls.phoneNumber.value,
      address: this.newGuestFormGroup.controls.address.value,
      roomId: Number(this.bookingInformationFormGroup.controls.roomNumber.value),
      checkIn: this.bookingInformationFormGroup.controls.checkInDate.value,
      checkOut: this.bookingInformationFormGroup.controls.checkOutDate.value,
    }

    return guest;
  }

  submitBooking() {

    this.showSpinner = true;

    let guest = this.buildGuest();

    this.service.bookNewGuest(guest).subscribe(result => {

      this.showSpinner = false;

      this.bookingInformationFormGroup.reset();
      this.newGuestFormGroup.reset();

      this.getRooms();

      console.log(result)
      this._snackBar.open(`Successfully added ${guest.firstName}`, 'Ok', {
        duration: 3000
      })
    },
      err => {
        this.showSpinner = false;
        console.log(err)
        this._snackBar.open(err.message, 'Ok', {
          duration: 3000
        })
      });

  }

  getRoomTypes() {
    this.roomService.getAllRoomTypes().subscribe(data => {
      this.roomTypes = data;
    },
      err => {

      });
  }

  getRooms() {
    this.roomService.getAllVacantRooms().subscribe(data => {
      console.log('vacant ', data)
      this.roomsResult = data.filter(x => x.roomStatus == 0);
    },
      err => {

      });
  }

  setRoomNumbers(roomTypeId: number) {

    console.log(roomTypeId)
    this.rooms = this.roomsResult.filter(x => x.roomTypeId == roomTypeId)
    console.log(this.rooms);
  }

}
