import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Room } from '../interfaces/room';
import { RoomType } from '../interfaces/roomType';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

    // Room
    getAllRooms(): Observable<Room[]> {
      return this.http.get<Room[]>(this.baseUrl + 'Rooms');
    }

    getOneRoom(id: number): Observable<Room> {
      return this.http.get<Room>(this.baseUrl + `Rooms/${id}`);
    }

    getAllRoomTypes(): Observable<RoomType[]> {
      return this.http.get<RoomType[]>(this.baseUrl + 'RoomTypes');
    }

    getOneRoomType(id: number): Observable<RoomType> {
      return this.http.get<RoomType>(this.baseUrl + `RoomTypes/${id}`);
    }


    createRoomType() {

    }
  
    createRoom() {
  
    }
  
    updateRoom() {
      
    }
}
