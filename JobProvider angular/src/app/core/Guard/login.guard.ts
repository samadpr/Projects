import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class LoginGuard implements CanActivate{

  canActivate(): boolean {
    return true;
  }
  // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
  //   throw new Error('Method not implemented.');
  // }
  
}
// export const loginGuard: CanActivateFn = (route, state) => {
//   return true;
// };
