import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const COMMON_MODULE = [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
]

const MAT_MODULE = [
  MatButtonModule,
  MatRippleModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatTooltipModule,
  MatTableModule,
  MatIconModule,
  MatCheckboxModule,
  MatRadioModule,
]

@NgModule({
  declarations: [],
  imports: [
    ...COMMON_MODULE,
    ...MAT_MODULE
  ],
  exports: [
    ...COMMON_MODULE,
    ...MAT_MODULE
  ]
})
export class ThemeModule { }
