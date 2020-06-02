import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  public displayedColumns: string[] = ['id', 'catalogType', 'catalogBrand', 'productName', 'price', 'description'];
  public productDataSource: any;
  constructor(public productService: ProductService) {
    productService.GetProducts().subscribe({
      next: value => this.productDataSource = value
    });
  }

  ngOnInit(): void {

  }
}
