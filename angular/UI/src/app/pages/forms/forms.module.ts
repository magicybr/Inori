import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsRoutingModule } from './forms-routing.module';
import { FormsComponent } from './forms.component';
import { ThemeModule } from '../theme/theme.module';
import { RegularFormsComponent } from './regular-forms/regular-forms.component';
import { WizardFormsComponent } from './wizard-forms/wizard-forms.component';


@NgModule({
  declarations: [
    FormsComponent,
    RegularFormsComponent,
    WizardFormsComponent
  ],
  imports: [
    CommonModule,
    ThemeModule,
    FormsRoutingModule
  ]
})
export class FormsModule { }
