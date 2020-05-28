import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { UserManager, User } from 'oidc-client';
import { ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: ServicesModule
})

export class OpenIdConnectService {

  private userManager = new UserManager(environment.openIdConnectSettings);
  // User 当前用户的信息
  private currentUser: User;

  userLoaded$ = new ReplaySubject<boolean>(1);

  constructor() {
    this.userManager.clearStaleState();
    this.userManager.getUser().then(user => {
      if (user) {
        this.currentUser = user;
        this.userLoaded$.next(true);
      } else {
        this.currentUser = null;
        this.userLoaded$.next(false);
      }
    }).catch(err => {
      console.log(err);
      this.currentUser = null;
      this.userLoaded$.next(false);
    });
  }
}
