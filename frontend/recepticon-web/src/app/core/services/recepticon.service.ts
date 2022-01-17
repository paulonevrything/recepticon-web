import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RecepticonService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }

  search(searchPhrase: string, markets: string[]): Observable<any> {

    let params = new HttpParams();
    params = params.append("searchPhrase", searchPhrase.trim())

    if (markets) {
      markets.forEach(market => {
        params = params.append("markets", market.trim())
      });
    }

    return this.http.get(this.baseUrl, {
      params: params,
    });
  }

  // Guests
  getGuestList() {

  }

  bookNewGuest() {

  }

  checkOutGuest() {

  }

  extendCheckout() {

  }

  // Users
  createUser() {

  }

  getUsers() {

  }

  getUser() {

  }

  deleteUser() {

  }

  updateUser() {

  }

  // Room
  createRoomType() {

  }

  createRoom() {

  }

  updateRoom() {
    
  }
}
