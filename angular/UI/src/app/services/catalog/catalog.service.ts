import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { Observable, of, from } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../auth/auth.service';
import { CatalogItemList, CatalogItem } from './catalog-item';
import { CatalogBrand, CatalogBrandList } from './catalog-brand';
import { CatalogType, CatalogTypelist } from './catalog-type';
import { find } from 'rxjs/operators';

@Injectable({
  providedIn: ServicesModule
})
export class CatalogService {

  constructor(
    private httpClient: HttpClient,
    private auth: AuthService
  ) { }

  // GetCatalogItems(): Observable<any> {
  //   return this.httpClient.get('http://localhost:5001/api/catalog/items', {
  //     headers: { 'Authorization': this.auth.currentUser.token_type + ' ' + this.auth.currentUser.access_token }
  //   });
  // }

  GetCatalogItems(): Observable<CatalogItem[]> {
    return of(CatalogItemList);
  }

  GetCatalogBrands(): Observable<CatalogBrand[]> {
    return of(CatalogBrandList);
  }

  GetCatalogTypes(): Observable<CatalogType[]> {
    return of(CatalogTypelist);
  }

  GetCatalogItemById(Id: number): Observable<CatalogItem> {
    return this.httpClient.get<CatalogItem>('http://localhost:5001/api/catalog/items/1');
    // return from(CatalogItemList).pipe(
    //   find(item => {
    //     return item.Id === Id;
    //   })
    // );
  }


}
