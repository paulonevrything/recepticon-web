import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTable } from '@angular/material/table';
import { User } from 'src/app/core/interfaces/user';
import { RecepticonService } from 'src/app/core/services/recepticon.service';
import { AddNewUserComponent } from '../components/add-new-user/add-new-user.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'username', 'role'];
  dataSource: User[] = [];

  @ViewChild(MatTable)
  table!: MatTable<User>;

  constructor(public dialog: MatDialog, private service: RecepticonService, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  addNewUser() {
    let dailogRef = this.dialog.open(AddNewUserComponent);
    dailogRef.afterClosed().subscribe(() => {
      this.getAllUsers();
    });
  }

  getAllUsers() {
    this.service.getUsers().subscribe(data => {
      console.log(data);
      this.dataSource = data;
    },
      err => {
        console.log(err)
        this._snackBar.open(err.error.message, 'Ok', {
          duration: 3000
        })
      });
  }

}