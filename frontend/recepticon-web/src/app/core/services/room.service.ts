import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Room } from '../interfaces/room';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {
    return this.http.post(this.baseUrl + 'Users/authenticate', {
      username: username,
      password: password
    });
  }

    // Room
    getAllRooms(): Observable<Room[]> {
      return this.http.get<Room[]>(this.baseUrl + 'Rooms');
    }

    getOneRoom(id: number): Observable<any> {
      return this.http.get(this.baseUrl + `Rooms/${id}`);
    }

    getAllRoomTypes(): Observable<any> {
      return this.http.get(this.baseUrl + 'RoomTypes');
    }

    getOneRoomType(id: number): Observable<any> {
      return this.http.get(this.baseUrl + `RoomTypes/${id}`);
    }


    createRoomType() {

    }
  
    createRoom() {
  
    }
  
    updateRoom() {
      
    }
}
