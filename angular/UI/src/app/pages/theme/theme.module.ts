import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatRippleModule, MAT_DATE_FORMATS } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { AmountWithDecimailsComponent } from './controls/amount-with-decimails/amount-with-decimails.component';

const COMMON_MODULE = [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
];

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
  MatDatepickerModule,
  MatMomentDateModule,
  MatDividerModule,
  MatExpansionModule,
  MatSortModule,
  MatPaginatorModule
];

@NgModule({
  declarations: [AmountWithDecimailsComponent],
  imports: [
    ...COMMON_MODULE,
    ...MAT_MODULE
  ],
  exports: [
    ...COMMON_MODULE,
    ...MAT_MODULE,
  ],
  providers: [
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
    {
      provide: MAT_DATE_FORMATS,
      useValue: {
        parse: {
          dateInput: ['l', 'LL'],
        },
        display: {
          dateInput: 'L',
          monthYearLabel: 'MMM YYYY',
          dateA11yLabel: 'LL',
          monthYearA11yLabel: 'MMMM YYYY',
        },
      },
    },
  ],
})
export class ThemeModule { }
