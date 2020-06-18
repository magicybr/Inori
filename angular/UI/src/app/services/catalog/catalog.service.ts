import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: ServicesModule
})
export class CatalogService {

  constructor(private httpClient: HttpClient) { }

  GetCatalogItems(): Observable<any> {
    return this.httpClient.get('http://localhost:5001/api/catalog/items');
  }
}
