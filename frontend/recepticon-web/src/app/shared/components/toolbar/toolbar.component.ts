import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {


  @Input() loggedIn: boolean = false;

  constructor(private tokenStorage: TokenStorageService, private router: Router) { }

  ngOnInit(): void {
  }

  logOut() {
    this.tokenStorage.signOut();
    this.router.navigateByUrl('auth');
  }

}
