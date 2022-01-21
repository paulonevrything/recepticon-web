import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TokenStorageService } from '../services/token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private tokenStorage: TokenStorageService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      let userRole = this.tokenStorage.getUser().role;

      console.log('storage-user', userRole)

      if(!userRole) {
        this.router.navigateByUrl('auth');
        return false;
      }
      console.log('route role ', route.data.role)
      console.log('user role ', userRole)

      if (userRole) {
        console.log('route role ', route.data.role)
        console.log('user role ', userRole)
        
        if (route.data.role && route.data.role != userRole) {
            // role not authorised so redirect to home page
            this.router.navigate(['/']);
            return false;
        }

        // authorised so return true
        return true;
    }
      
    return true;
  }
  
}
