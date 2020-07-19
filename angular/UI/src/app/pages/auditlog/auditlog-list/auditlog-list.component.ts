import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { AuditlogService } from 'src/app/services/auditlog/auditlog.service';
import { delay, mergeMap } from 'rxjs/operators';
import { of } from 'rxjs';
import { AuditlogInfo } from 'src/app/services/auditlog/auditlog-info';
import { MatPaginator } from '@angular/material/paginator';


@Component({
  selector: 'app-auditlog-list',
  templateUrl: './auditlog-list.component.html',
  styleUrls: ['./auditlog-list.component.css']
})
export class AuditlogListComponent implements OnInit {
  public auditlogDataSource: AuditlogInfo[];
  public displayedColumns: string[] = ['Id', 'BrowserInfo', 'ServiceName', 'MethodName', 'ExecutionTime', 'ExecutionDuration'];
  public dataSource: MatTableDataSource<AuditlogInfo>;

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private route: ActivatedRoute, private auditlogService: AuditlogService) {
    auditlogService.getAuditlogs().pipe(delay(1000), mergeMap(items => of(items))).subscribe({
      next: (data) => {
        this.auditlogDataSource = data;
        this.dataSource = new MatTableDataSource(this.auditlogDataSource);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  ngOnInit(): void {

  }
}
