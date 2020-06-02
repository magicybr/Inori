import { Routes } from '@angular/router';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { WizardFormsComponent } from '../../forms/wizard-forms/wizard-forms.component';
import { RegularFormsComponent } from '../../forms/regular-forms/regular-forms.component';
import { ProductsComponent } from '../../products/products.component';

export const AdminLayoutRoutes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'regularforms', component: RegularFormsComponent },
  { path: 'wizardforms', component: WizardFormsComponent },
  {
    path: 'products', loadChildren: () => import('../../products/products.module').then(m => m.ProductsModule)
  }
];
