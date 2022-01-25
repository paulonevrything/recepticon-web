import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { RecepticonService } from 'src/app/core/services/recepticon.service';
import { User } from 'src/app/core/interfaces/user';
import { Role } from 'src/app/core/interfaces/role';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CreateUser } from 'src/app/core/interfaces/createUser';

@Component({
  selector: 'app-add-new-user',
  templateUrl: './add-new-user.component.html',
  styleUrls: ['./add-new-user.component.css']
})
export class AddNewUserComponent implements OnInit {

  newUserFormGroup!: FormGroup;
  showSpinner: boolean = false;

  constructor(private fb: FormBuilder, private service: RecepticonService,
    private _snackBar: MatSnackBar) { }

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

      confirmPassword: new FormControl('', Validators.compose([
        Validators.required
      ])),

      role: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })

  }

  addNewUser(form: any) {

    this.showSpinner = true;

    let user: CreateUser = {
      firstName: form.firstName,
      lastName: form.lastName,
      username: form.username,
      password: form.password,
      role: form.role,
      confirmPassword: form.confirmPassword
    }

    this.service.createUser(user).subscribe(result => {

      this.showSpinner = false;

      this.newUserFormGroup.reset();

      console.log(result)
      this._snackBar.open(`Successfully added ${form.firstName}`, 'Ok', {
        duration: 3000
      })
    },
      err => {
        this.showSpinner = false;
      });
  }

}
