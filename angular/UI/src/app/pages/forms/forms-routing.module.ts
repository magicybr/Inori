import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsComponent } from './forms.component';
import { RegularFormsComponent } from './regular-forms/regular-forms.component';
import { WizardFormsComponent } from './wizard-forms/wizard-forms.component';


const routes: Routes = [
  {
    path: '', component: FormsComponent,
    children: [
      { path: 'regular', component: RegularFormsComponent },
      { path: 'wizard', component: WizardFormsComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FormsRoutingModule { }
