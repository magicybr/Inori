import { NgModule, Optional, SkipSelf } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServicesModule } from '../services/services.module';
import { ThemeModule } from '../theme/theme.module';
import { PagesModule } from '../pages/pages.module';



@NgModule({
  declarations: [],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ServicesModule,
    ThemeModule,
    PagesModule
  ], exports: [
    BrowserModule,
    BrowserAnimationsModule,
    ServicesModule,
    ThemeModule,
    PagesModule
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(`CoreModule has already been loaded. Import Core modules in the AppModule only.`);
    }
  }
}
