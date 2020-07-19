import { Component, OnInit, OnDestroy, ElementRef } from '@angular/core';
import { MatFormFieldControl } from '@angular/material/form-field';
import { Subject } from 'rxjs';
import { NgControl, FormBuilder, FormGroup } from '@angular/forms';
import { FocusMonitor } from '@angular/cdk/a11y';
export class InoriTel {
  constructor(public area: string, public exchange: string, public subscriber: string) { }
}
@Component({
  selector: 'app-inori-tel-input',
  templateUrl: './inori-tel-input.component.html',
  styleUrls: ['./inori-tel-input.component.scss'],
  providers: [{ provide: MatFormFieldControl, useExisting: InoriTelInput }],
  // tslint:disable-next-line:no-host-metadata-property
  host: {
    '[class.example-floating]': 'shouldLabelFloat',
    '[id]': 'id',
    '[attr.aria-describedby]': 'describedBy',
  }
})


// tslint:disable-next-line:component-class-suffix
export class InoriTelInput implements MatFormFieldControl<InoriTel>, OnDestroy {
  value: InoriTel;
  placeholder: string;
  ngControl: NgControl;
  focused: boolean;
  empty: boolean;
  shouldLabelFloat: boolean;
  required: boolean;
  disabled: boolean;
  errorState: boolean;
  autofilled?: boolean;

  // tslint:disable-next-line: member-ordering
  static inoriTelNextId = 0;
  id = `inori-tel-input-${InoriTelInput.inoriTelNextId++}`;
  controlType = 'inori-tel-input';

  parts: FormGroup;
  stateChanges = new Subject<void>();

  constructor(fb: FormBuilder, private fm: FocusMonitor, private elRef: ElementRef<HTMLElement>) {
    this.parts = fb.group({
      area: '',
      exchange: '',
      subscriber: '',
    });

    console.log(elRef);

    fm.monitor(elRef, true).subscribe(origin => {
      this.focused = !!origin;
      this.stateChanges.next();
    });
  }

  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  setDescribedByIds(ids: string[]): void {
    throw new Error('Method not implemented.');
  }

  onContainerClick(event: MouseEvent): void {
    throw new Error('Method not implemented.');
  }

}
