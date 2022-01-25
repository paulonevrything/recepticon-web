import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RoomType } from 'src/app/core/interfaces/roomType';
import { RoomService } from 'src/app/core/services/room.service';

@Component({
  selector: 'app-add-new-room',
  templateUrl: './add-new-room.component.html',
  styleUrls: ['./add-new-room.component.css']
})
export class AddNewRoomComponent implements OnInit {

  newRoomFormGroup!: FormGroup;
  showSpinner: boolean = false;

  roomTypes: RoomType[] = [];

  constructor(private fb: FormBuilder, private roomService: RoomService,
    private _snackBar: MatSnackBar) { }

  ngOnInit(): void {

    this.getRoomTypes();

    this.newRoomFormGroup = this.fb.group({

      roomNumber: new FormControl('', Validators.compose([
        Validators.required
      ])),

      roomType: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

  }

  addNewRoom(form: any) {

    this.showSpinner = true;

    this.roomService.createRoom(form.roomNumber, form.roomType).subscribe(result => {

      this.showSpinner = false;
      this.newRoomFormGroup.reset();

      console.log(result)
      this._snackBar.open(`Successfully added Room ${form.roomNumber}`, 'Ok', {
        duration: 3000
      })
    },
      err => {
        this.showSpinner = false;
      });
  }

  getRoomTypes() {
    this.roomService.getAllRoomTypes().subscribe(data => {
      console.log(data);
      this.roomTypes = data;
    },
    err => {

    });
  }

}
