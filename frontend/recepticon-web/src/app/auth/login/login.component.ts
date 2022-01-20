import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  fieldTextType: boolean = false;

  loginFormGroup!: FormGroup;

  showSpinner: boolean = false;

  constructor(private fb: FormBuilder, private service: AuthService, private router: Router,
    private _snackBar: MatSnackBar, private tokenStorage: TokenStorageService) { }

  ngOnInit(): void {

    this.loginFormGroup = this.fb.group({

      username: new FormControl('', Validators.compose([
        Validators.required
      ])),

      password: new FormControl('', Validators.compose([
        Validators.required
      ]))
    })
  }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }

  login(form: any) {

    this.showSpinner = true;

    this.service.login(form.username, form.password).subscribe(result => {

      this.showSpinner = false;
      console.log(result)

      this.tokenStorage.saveToken(result.accessToken);
      this.tokenStorage.saveUser(result);

      this.navigateByRole();
    },
      err => {
        this.showSpinner = false;
        console.log(err)
        this._snackBar.open(err.error.message, 'Ok', {
          duration: 3000
        })
      });
  }

  navigateByRole() {

    let role = this.tokenStorage.getUser().role;

    if(role == 1) {

      this.router.navigateByUrl('admin');

    } else {

      this.router.navigateByUrl('receptionist');

    }
  }

}
