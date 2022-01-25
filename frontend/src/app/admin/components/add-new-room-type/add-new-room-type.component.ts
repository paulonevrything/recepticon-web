import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RoomService } from 'src/app/core/services/room.service';

@Component({
  selector: 'app-add-new-room-type',
  templateUrl: './add-new-room-type.component.html',
  styleUrls: ['./add-new-room-type.component.css']
})
export class AddNewRoomTypeComponent implements OnInit {

  newRoomTypeFormGroup!: FormGroup;
  showSpinner: boolean = false;

  constructor(private fb: FormBuilder, private roomService: RoomService,
    private _snackBar: MatSnackBar) { }

  ngOnInit(): void {

    this.newRoomTypeFormGroup = this.fb.group({

      roomType: new FormControl('', Validators.compose([
        Validators.required
      ])),

      price: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

  }

  addNewRoomType(form: any) {

    this.showSpinner = true;

    this.roomService.createRoomType(form.roomType, form.price).subscribe(result => {

      this.showSpinner = false;

      this.newRoomTypeFormGroup.reset();

      console.log(result)
      this._snackBar.open(`Successfully added ${form.roomType} Room Type`, 'Ok', {
        duration: 3000
      })
    },
      err => {
        this.showSpinner = false;
      });
  }

}
