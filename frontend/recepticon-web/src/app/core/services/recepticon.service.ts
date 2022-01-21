import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class RecepticonService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  // Users
  createUser() {

  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'Users');
  }

  getUser() {

  }

  deleteUser() {

  }

  updateUser() {

  }


}
