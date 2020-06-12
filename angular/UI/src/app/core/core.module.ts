import { NgModule, Optional, SkipSelf } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ComponentsModule } from '../pages/components/components.module';
import { AdminLayoutComponent } from '../pages/layout/admin-layout/admin-layout.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from '../app-routing.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ServicesModule } from '../services/services.module';
import { AuthorizationHeaderInterceptor } from '../services/Interceptors/authorization-header.interceptor';

@NgModule({
  declarations: [
    AdminLayoutComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ServicesModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
  ], exports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ServicesModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
  ], providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationHeaderInterceptor,
      multi: true
    }
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(`CoreModule has already been loaded. Import Core modules in the AppModule only.`);
    }
  }
}
