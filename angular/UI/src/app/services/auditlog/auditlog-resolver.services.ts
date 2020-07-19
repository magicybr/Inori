import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuditlogService } from './auditlog.service';
import { take, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable({ providedIn: ServicesModule })
export class AuditlogResolverService implements Resolve<any>{

  constructor(private auditlogService: AuditlogService, private router: Router) {

  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.auditlogService.getAuditlogs().pipe(
      take(1),
      mergeMap(AuditlogItems => of(AuditlogItems))
    );
  }
}
