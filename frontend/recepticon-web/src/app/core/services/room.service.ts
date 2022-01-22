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

    getAllVacantRooms(): Observable<Room[]> {
      return this.http.get<Room[]>(this.baseUrl + 'Rooms/vacant');
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

    createRoomType(roomTypeName: string, price: number): Observable<any> {
      return this.http.post(this.baseUrl + 'RoomTypes', {
        roomTypeName: roomTypeName,
        price: price
      });
    }
  
    createRoom(roomName: string, roomTypeId: number): Observable<any> {
      return this.http.post(this.baseUrl + 'Rooms', {
        roomNumber: roomName,
        roomTypeId: Number(roomTypeId)
      });
    }
  
    updateRoom() {
      
    }
}
