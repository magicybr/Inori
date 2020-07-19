import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuditlogComponent } from './auditlog.component';
import { AuditlogListComponent } from './auditlog-list/auditlog-list.component';
import { AuditlogDetailsComponent } from './auditlog-details/auditlog-details.component';
import { AuditlogResolverService } from 'src/app/services/auditlog/auditlog-resolver.services';


const routes: Routes = [
  {
    path: '', component: AuditlogComponent,
    children: [
      {
        path: '',
        component: AuditlogListComponent,
        // resolve: {
        //   AuditlogItems: AuditlogResolverService
        // }
      },
      {
        path: ':id',
        component: AuditlogDetailsComponent,
        resolve: {

        }
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuditlogRoutingModule { }
