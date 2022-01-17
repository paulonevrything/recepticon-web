import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { RecepticonService } from 'src/app/core/services/recepticon.service';

@Component({
  selector: 'app-add-new-room',
  templateUrl: './add-new-room.component.html',
  styleUrls: ['./add-new-room.component.css']
})
export class AddNewRoomComponent implements OnInit {

  newRoomFormGroup!: FormGroup;

  constructor(private fb: FormBuilder, private service: RecepticonService) { }

  ngOnInit(): void {

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

  }

}
