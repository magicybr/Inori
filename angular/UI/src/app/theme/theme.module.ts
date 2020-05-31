import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ThemeRoutingModule } from './theme-routing.module';

import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';

import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';


const MAT_MODULE = [
  MatButtonModule,
  MatRippleModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatTooltipModule,
];

const SHARE_COMPONENT = [

]

const LAYOUT_COMPONENT = [
  NavbarComponent,
  SidebarComponent,
  FooterComponent
]

@NgModule({
  declarations: [
    ...LAYOUT_COMPONENT,
  ],
  imports: [
    CommonModule,
    ...MAT_MODULE,
    ...SHARE_COMPONENT,
    ThemeRoutingModule
  ],
  exports: [
    ...MAT_MODULE,
    ...SHARE_COMPONENT
  ]
})
export class ThemeModule { }
