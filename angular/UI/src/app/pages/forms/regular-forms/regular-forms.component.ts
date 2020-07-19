import { Component, OnInit } from '@angular/core';
import { Moment } from 'moment';
import * as moment from 'moment';
@Component({
  selector: 'app-regular-forms',
  templateUrl: './regular-forms.component.html',
  styleUrls: ['./regular-forms.component.scss']
})
export class RegularFormsComponent implements OnInit {
  workingDayFilter = (d: Moment | null): boolean => {
    const day = (d || moment()).day();
    return day !== 0 && day !== 6;
  }
  FromToDateFilter = (d: Moment | null): boolean => {
    const day = d.date();
    const currentDay = moment().date();
    return day > currentDay;
  }
  constructor() { }

  ngOnInit(): void {
  }

}
