import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpHeaderCommonInterceptor } from './Interceptors/http-header-common.interceptor';

@NgModule({
  declarations: [],
  imports: [],
  exports: [],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: HttpHeaderCommonInterceptor,
    multi: true
  }]
})
export class ServicesModule { }
