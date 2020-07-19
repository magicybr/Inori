import { Injectable } from "@angular/core";
import { ServicesModule } from '../services.module';
import { Observable, from } from 'rxjs';
import { filter } from 'rxjs/operators';

@Injectable({ providedIn: ServicesModule })

export class UsersServices {
  constructor() {
  }

  GetUsers() {
    return from(users);
  }

  GetUserById(Id: number): Observable<UserInfo> {
    return from(users).pipe(filter(v => v.Id === Id));
  }

  Update(userInfo: UserInfo) {

  }
}

export const users: UserInfo[] = [
  {
    Id: 1,
    username: '张三',
    email: 'zhangsan@outlook.com',
    birthday: '1988-09-08',
    phone: '13397983365'
  },
];

export interface UserInfo {
  Id: number;
  username: string;
  email: string;
  birthday: string;
  phone: string;
};

