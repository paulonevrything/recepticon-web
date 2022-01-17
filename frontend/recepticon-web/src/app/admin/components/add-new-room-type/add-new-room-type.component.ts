import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { RecepticonService } from 'src/app/core/services/recepticon.service';

@Component({
  selector: 'app-add-new-room-type',
  templateUrl: './add-new-room-type.component.html',
  styleUrls: ['./add-new-room-type.component.css']
})
export class AddNewRoomTypeComponent implements OnInit {

  newRoomTypeFormGroup!: FormGroup;

  constructor(private fb: FormBuilder, private service: RecepticonService) { }

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

  }

}
