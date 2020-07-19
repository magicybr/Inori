import { NgModule } from '@angular/core';
import { ThemeModule } from '../theme/theme.module';

import { CatalogRoutingModule } from './catalog-routing.module';
import { CatalogListComponent } from './catalog-list/catalog-list.component';
import { CatalogComponent } from './catalog.component';
import { CatalogInfoComponent } from './catalog-info/catalog-info.component';
import { TextSubstringPipe } from '../share/pipes/textsubstring.pipe';


@NgModule({
  declarations: [
    CatalogListComponent,
    CatalogComponent,
    CatalogInfoComponent,
    TextSubstringPipe
  ],
  imports: [
    ThemeModule,
    CatalogRoutingModule
  ]
})

export class CatalogModule { }
