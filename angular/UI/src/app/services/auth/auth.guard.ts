import { CanActivate, CanActivateChild, CanLoad, ActivatedRouteSnapshot, RouterStateSnapshot, Route, UrlTree, UrlSegment, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { ServicesModule } from '../services.module';

@Injectable({ providedIn: ServicesModule})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {
  constructor(private authService: AuthService, private router: Router) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
    : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

    const url: string = state.url;
    console.log(`AuthGuard:CanActive Method,url:${url}`);
    return this.checkLogin(url);
  }
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot)
    : boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

    console.log(`AuthGuard:CanChildActive Method,route:${childRoute},state:${state}`);
    return this.canActivate(childRoute, state);

  }
  canLoad(route: Route, segments: UrlSegment[]): boolean | Observable<boolean> | Promise<boolean> {
    const url = `/${route.path}`;
    console.log(`AuthGuard:CanLoad Method,url:${url}`);
    return this.checkLogin(url);
  }
  checkLogin(url: string): Observable<boolean> {

    const isLoggedIn = this.authService.isLoggedInObs();
    isLoggedIn.subscribe((loggedin) => {
      if (!loggedin) {
        this.authService.triggerSignIn();
        console.log('unauthorized');
      }
    });

    return isLoggedIn;
  }
}
