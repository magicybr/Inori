import { NgModule } from '@angular/core';
import { AdminLayoutRoutes } from './admin-layout-routing.module';
import { RouterModule } from '@angular/router';

import { ThemeModule } from '../../theme/theme.module';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { RegularTablesComponent } from '../../tables/regular-tables/regular-tables.component';


@NgModule({
  declarations: [
    DashboardComponent,
    RegularTablesComponent,
  ],
  imports: [
    ThemeModule,
    RouterModule.forChild(AdminLayoutRoutes)
  ], exports: [

  ]
})
export class AdminLayoutModule { }
