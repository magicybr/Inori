import { NgModule } from '@angular/core';
import { AuditlogRoutingModule } from './auditlog-routing.module';
import { ThemeModule } from '../theme/theme.module';
import { AuditlogListComponent } from './auditlog-list/auditlog-list.component';
import { AuditlogComponent } from './auditlog.component';
import { AuditlogDetailsComponent } from './auditlog-details/auditlog-details.component';
import { ServiceNameSplitPipe } from './auditlog-list/servicename-split.pipe';


@NgModule({
  declarations: [
    AuditlogListComponent,
    AuditlogComponent,
    AuditlogDetailsComponent,
    ServiceNameSplitPipe
  ],
  imports: [
    ThemeModule,
    AuditlogRoutingModule
  ]
})
export class AuditlogModule { }
