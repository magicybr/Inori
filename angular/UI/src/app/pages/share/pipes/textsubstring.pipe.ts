import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'TextSubString' })

export class TextSubstringPipe implements PipeTransform {
  transform(value: string, len: number): string {
    // console.log(value.length);
    // return value;
    // console.log(len);
    // console.log(value.substring(0, len));
    return value.substr(0, len) + '...';
  }
}
