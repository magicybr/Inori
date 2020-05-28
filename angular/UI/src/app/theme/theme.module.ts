import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SiderBarComponent } from './sider-bar/sider-bar.component';
import { FooterComponent } from './footer/footer.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { MatSliderModule } from '@angular/material/slider';
import { MatToolbarModule } from '@angular/material/toolbar';

const PAGE_COMPONENT = [DashboardComponent, NavBarComponent, SiderBarComponent, FooterComponent];
const MAT_MODULE = [MatToolbarModule, MatSliderModule];
@NgModule({
  declarations: [...PAGE_COMPONENT],
  imports: [
    CommonModule,
    ...MAT_MODULE
  ],
  exports: [...PAGE_COMPONENT]
})
export class ThemeModule { }
