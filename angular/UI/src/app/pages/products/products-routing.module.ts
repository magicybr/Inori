import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductInfoComponent } from './product-info/product-info.component';
import { ProductsComponent } from './products.component';
import { CatalogResolverService } from 'src/app/services/catalog/catalog-resolver.service';



const routes: Routes = [
  {
    path: '', component: ProductsComponent,
    children: [
      {
        path: '',
        component: ProductListComponent,
        resolve: {
          catalogItems: CatalogResolverService
        }
      },
      { path: ':id', component: ProductInfoComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
