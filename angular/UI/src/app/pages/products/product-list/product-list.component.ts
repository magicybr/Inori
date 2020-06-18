import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product/product.service';
import { CatalogService } from 'src/app/services/catalog/catalog.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  public catalogDisplayedColumns: string[] = ['id', 'productName', 'description', 'price', 'availableStock'];
  public catalogDataSource: any;

  constructor(
    private catalogService: CatalogService,
    private route: ActivatedRoute
  ) {
    this.route.data.subscribe({
      next: (data) => this.catalogDataSource = data.catalogItems
    });
  }

  ngOnInit(): void {

  }
}
