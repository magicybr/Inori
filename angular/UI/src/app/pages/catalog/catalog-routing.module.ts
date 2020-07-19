import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CatalogComponent } from './catalog.component';
import { CatalogListComponent } from './catalog-list/catalog-list.component';
import { CatalogItemsResolverService } from 'src/app/services/catalog/catalog-item-resolver.service';
import { CatalogInfoComponent } from './catalog-info/catalog-info.component';
import { CatalogInfoResolverService } from 'src/app/services/catalog/catalog-info-resolver.service';


const routes: Routes = [
  {
    path: '',
    component: CatalogComponent,
    children: [
      {
        path: '',
        component: CatalogListComponent,
        resolve: {
          CatalogItems: CatalogItemsResolverService
        }
      },
      {
        path: ':Id',
        component: CatalogInfoComponent,
        resolve: {
          catalogData: CatalogInfoResolverService
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogRoutingModule { }
