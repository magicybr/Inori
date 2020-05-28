import { NgModule, Optional, SkipSelf } from '@angular/core';
import { ThemeModule } from 'src/app/theme/theme.module';
import { ServicesModule } from 'src/app/services/services.module';
import { PageModule } from 'src/app/pages/page/page.module';


@NgModule({
  declarations: [],
  imports: [
    ServicesModule,
    ThemeModule,
    PageModule
  ], exports: [
    ServicesModule,
    ThemeModule,
    PageModule
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      // 核心模块已经被加载,在AppModule中仅导入一次核心模块
      throw new Error(`CoreModule has already been loaded. Import Core modules in the AppModule only.`);
    }
  }
}
