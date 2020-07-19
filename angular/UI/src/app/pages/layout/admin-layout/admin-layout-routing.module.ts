import { Routes } from '@angular/router';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { AdminLayoutComponent } from './admin-layout.component';
import { AuthGuard } from 'src/app/services/auth/auth.guard';


export const AdminLayoutRoutes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        canActivateChild: [AuthGuard],
        children: [
          {
            path: 'dashboard',
            component: DashboardComponent,
          },
          {
            path: 'forms',
            loadChildren: () => import('../../forms/forms.module').then(m => m.FormsModule),
          },
          {
            path: 'products',
            loadChildren: () => import('../../products/products.module').then(m => m.ProductsModule),
          },
          {
            path: 'auditlog',
            loadChildren: () => import('../../auditlog/auditlog.module').then(m => m.AuditlogModule),
          },
          {
            path: 'items',
            loadChildren: () => import('../../catalog/catalog.module').then(m => m.CatalogModule),
          },
          {
            path: 'users',
            loadChildren: () => import('../../users/users.module').then(m => m.UsersModule)
          }
        ]
      }
    ]
  },
];
