import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CreateUser } from '../interfaces/createUser';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class RecepticonService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  // Users
  createUser(user: CreateUser): Observable<any> {
    return this.http.post(this.baseUrl + 'Users', user);
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
