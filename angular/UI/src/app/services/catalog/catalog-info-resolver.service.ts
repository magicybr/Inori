import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot, Router, ActivatedRoute } from '@angular/router';
import { CatalogService } from './catalog.service';
import { take } from 'rxjs/operators';
import { forkJoin, Observable } from 'rxjs';
import { CatalogType } from './catalog-type';
import { CatalogBrand } from './catalog-brand';
import { CatalogItem } from './catalog-item';

type ReturnType = [CatalogBrand[], CatalogType[]];
@Injectable({ providedIn: ServicesModule })
export class CatalogInfoResolverService implements Resolve<ReturnType>{
  private Id: any;
  constructor(private catalogService: CatalogService, private router: Router, private route: ActivatedRoute) {
    // this.route.params.subscribe(p => {
    //   console.log(p);
    // });
    // this.route.queryParams.subscribe(params => {
    //   // console.log(params);
    //   this.Id = params.Id;
    // });
    // console.log(this.route.snapshot.params);
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ReturnType> {
    return forkJoin([
      this.catalogService.GetCatalogBrands(),
      this.catalogService.GetCatalogTypes(),
    ]).pipe(take(1));
  }
}
