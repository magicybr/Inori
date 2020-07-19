import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { CatalogService } from './catalog.service';
import { ServicesModule } from '../services.module';
import { take, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';
import { CatalogItem } from './catalog-item';

@Injectable({ providedIn: ServicesModule })

export class CatalogItemsResolverService implements Resolve<CatalogItem[]>{
  constructor(private catalogService: CatalogService, private router: Router) {

  }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.catalogService.GetCatalogItems().pipe(
      take(1),
      mergeMap(catalogItems => of(catalogItems))
    );
  }
}
