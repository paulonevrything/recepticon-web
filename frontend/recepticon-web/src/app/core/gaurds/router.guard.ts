import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanDeactivate, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenStorageService } from '../services/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class RouterGuard implements CanActivate {

  constructor(private router: Router, private tokenStorage: TokenStorageService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    let role = this.tokenStorage.getUser().role;

    if (role != undefined) {


      if (route.data.role != undefined && route.data.role != role) {

        console.log('route role ', route.data.role)
        console.log('user role ', role)

        this.router.navigateByUrl('auth');
        return false;
      }

      return true;
    }

    this.router.navigateByUrl('auth');
    return false;
  }
}
