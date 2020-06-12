import { Injectable, EventEmitter } from '@angular/core';
import { UserManager, User } from 'oidc-client';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { map } from 'rxjs/operators';
import { ServicesModule } from '../services.module';

@Injectable({
  providedIn: ServicesModule
})

export class AuthService {
  mgr: UserManager = new UserManager(environment.openIdConnectSettings);
  userLoadededEvent: EventEmitter<User> = new EventEmitter<User>();
  currentUser: User;
  loggedIn = false;
  loadedUserSub: any;
  authHeaders: Headers;

  constructor(private httpClient: HttpClient) {

    this.mgr.clearStaleState();

    this.mgr.getUser().then((user) => {
      if (user) {
        this.loggedIn = true;
        this.currentUser = user;
        this.userLoadededEvent.emit(user);
      } else {
        this.loggedIn = false;
      }
    }).catch((err) => {
      this.loggedIn = false;
    });

    this.mgr.events.addUserLoaded((user) => {
      this.currentUser = user;
      this.loggedIn = !(user === undefined);
      if (!environment.production) {
        console.log('authService addUserLoaded', user);
      }
    });

    this.mgr.events.addUserUnloaded(() => {
      if (!environment.production) {
        console.log('user unloaded');
      }
      this.loggedIn = false;
    });

  }

  triggerSignIn() {
    this.mgr.signinRedirect().then(() => {
      console.log('triggerSignIn');
    });
  }

  triggerSignOut() {
    this.mgr.getUser().then(user => {
      return this.mgr.signoutRedirect({ id_token_hint: user.id_token }).then(resp => {
        console.log('Sign Out', resp);
      }).catch((err) => {
        console.log(err);
      });
    });
  }

  isLoggedInObs(): Observable<boolean> {
    return from(this.mgr.getUser()).pipe(map<User, boolean>((user) => {
      if (user) {
        return true;
      } else {
        return false;
      }
    }));
  }

  getUser() {
    this.mgr.getUser().then((user) => {
      this.currentUser = user;
      console.log('got user', user);
      this.userLoadededEvent.emit(user);
    }).catch((err) => {
      console.log(err);
    });
  }
}
