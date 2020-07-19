import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { CatalogService } from './catalog.service';
import { take, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';


@Injectable({ providedIn: ServicesModule })

export class CatalogResolverService implements Resolve<any> {
  constructor(private catalogService: CatalogService, private router: Router) {

  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.catalogService.GetCatalogItems().pipe(
      take(1),
      mergeMap(catalogItems => of(catalogItems))
    );
  }
}
