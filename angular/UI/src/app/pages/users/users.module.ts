import { NgModule } from '@angular/core';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { UserListComponent } from './user-list/user-list.component';
import { ThemeModule } from '../theme/theme.module';
import { UserInfoComponent } from './user-info/user-info.component';


@NgModule({
  declarations: [UsersComponent, UserListComponent, UserInfoComponent],
  imports: [
    ThemeModule,
    UsersRoutingModule
  ]
})
export class UsersModule { }
