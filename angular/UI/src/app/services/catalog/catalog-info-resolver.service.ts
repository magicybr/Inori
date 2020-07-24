import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router, ActivatedRoute } from '@angular/router';
import { CatalogService } from './catalog.service';
import { take } from 'rxjs/operators';
import { forkJoin, Observable } from 'rxjs';
import { CatalogType } from './catalog-type';
import { CatalogBrand } from './catalog-brand';
import { CatalogItem } from './catalog-item';

type ReturnType = [CatalogBrand[], CatalogType[], CatalogItem];
@Injectable({ providedIn: ServicesModule })
export class CatalogInfoResolverService implements Resolve<ReturnType>{
  constructor(private catalogService: CatalogService, private router: Router, private route: ActivatedRoute) {

  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ReturnType> {
    return forkJoin([
      this.catalogService.GetCatalogBrands(),
      this.catalogService.GetCatalogTypes(),
      this.catalogService.GetCatalogItemById(route.params.Id)
    ]).pipe(take(1));
  }
}
