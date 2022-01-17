import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { RecepticonService } from 'src/app/core/services/recepticon.service';

@Component({
  selector: 'app-add-new-user',
  templateUrl: './add-new-user.component.html',
  styleUrls: ['./add-new-user.component.css']
})
export class AddNewUserComponent implements OnInit {

  newUserFormGroup!: FormGroup;

  constructor(private fb: FormBuilder, private service: RecepticonService) { }

  ngOnInit(): void {

    this.newUserFormGroup = this.fb.group({

      firstName: new FormControl('', Validators.compose([
        Validators.required
      ])),

      lastName: new FormControl('', Validators.compose([
        Validators.required
      ])),

      username: new FormControl('', Validators.compose([
        Validators.required
      ])),

      password: new FormControl('', Validators.compose([
        Validators.required
      ])),

      role: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

  }

  addNewUser(form: any) {

  }

}
