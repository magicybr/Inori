import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { SecurityHeadersInterceptor } from './Interceptors/security-headers.interceptor';

@NgModule({
  declarations: [],
  imports: [],
  exports: [],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: SecurityHeadersInterceptor,
    multi: true
  }]
})
export class ServicesModule { }
