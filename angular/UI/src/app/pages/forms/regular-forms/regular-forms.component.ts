import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-regular-forms',
  templateUrl: './regular-forms.component.html',
  styleUrls: ['./regular-forms.component.scss']
})
export class RegularFormsComponent implements OnInit {
  // CHECKBOX
  checked = false;
  indeterminate = false;
  labelPosition: 'before' | 'after' = 'after';
  disabled = false;
  constructor() { }

  ngOnInit(): void {
  }

}
