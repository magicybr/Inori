import { NgModule } from '@angular/core';
import { AdminLayoutRoutes } from './admin-layout-routing.module';
import { RouterModule } from '@angular/router';

import { ThemeModule } from '../../theme/theme.module';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { RegularTablesComponent } from '../../tables/regular-tables/regular-tables.component';
import { WizardFormsComponent } from '../../forms/wizard-forms/wizard-forms.component';
import { RegularFormsComponent } from '../../forms/regular-forms/regular-forms.component';
import { ProductsModule } from '../../products/products.module';


@NgModule({
  declarations: [
    DashboardComponent,
    RegularFormsComponent,
    WizardFormsComponent,
    RegularTablesComponent
  ],
  imports: [
    ThemeModule,
    // ProductsModule,
    RouterModule.forChild(AdminLayoutRoutes)
  ], exports: [

  ]
})
export class AdminLayoutModule { }
