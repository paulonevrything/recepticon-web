import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Guest } from '../interfaces/guest';

@Injectable({
  providedIn: 'root'
})
export class GuestService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

    // Guests
    getGuestList(): Observable<Guest[]> {
      return this.http.get<Guest[]>(this.baseUrl + 'Rooms');
    }
  
    bookNewGuest() {
  
    }
  
    checkOutGuest() {
  
    }
  
    extendCheckout() {
  
    }
}
