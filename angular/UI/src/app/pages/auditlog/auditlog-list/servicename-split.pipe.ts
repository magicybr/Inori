import { PipeTransform, Pipe } from '@angular/core';

@Pipe({ name: 'ServiceNameSplit' })
export class ServiceNameSplitPipe implements PipeTransform {
  transform(value: string, ...args: any[]): string {
    return value.substr(value.lastIndexOf('.') + 1);
  }
}
