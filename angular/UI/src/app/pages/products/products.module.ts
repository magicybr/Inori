import { NgModule } from '@angular/core';

import { ProductsRoutingModule } from './products-routing.module';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductInfoComponent } from './product-info/product-info.component';
import { ThemeModule } from '../theme/theme.module';
import { ProductsComponent } from './products.component';


@NgModule({
  declarations: [
    ProductInfoComponent,
    ProductListComponent,
    ProductsComponent,
  ],
  imports: [
    ThemeModule,
    ProductsRoutingModule
  ]
})
export class ProductsModule { }
