import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  public catalogDisplayedColumns: string[] = ['id', 'productName', 'description', 'price', 'availableStock'];
  public catalogDisplayedColumnsToSelect: string[] = ['select', 'id', 'productName', 'description', 'price', 'availableStock', 'action'];
  public catalogDataSource: any;

  constructor(
    private route: ActivatedRoute
  ) {
    this.route.data.subscribe({
      next: (data) => this.catalogDataSource = data.catalogItems
    });
  }

  ngOnInit(): void {

  }
}
