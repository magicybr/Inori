import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
import { CatalogType } from 'src/app/services/catalog/catalog-type';
import { CatalogBrand } from 'src/app/services/catalog/catalog-brand';
import { NotificationService } from 'src/app/services/share/notification.services';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CatalogItem } from 'src/app/services/catalog/catalog-item';
import { CatalogService } from 'src/app/services/catalog/catalog.service';

declare var $: any;

@Component({
  selector: 'app-catalog-info',
  templateUrl: './catalog-info.component.html',
  styleUrls: ['./catalog-info.component.scss']
})
export class CatalogInfoComponent implements OnInit {
  catalogTypeSource: CatalogType[];
  catalogBrandSource: CatalogBrand[];
  catalogItem: CatalogItem;
  catalogItemForm: FormGroup;
  catalogBrandSelectedValue: string;
  catalogTypeSelectedValue: string;
  constructor(
    private route: ActivatedRoute,
    private notification: NotificationService,
    private fb: FormBuilder,
    private catalogService: CatalogService
  ) {

    this.catalogItemForm = this.fb.group({
      id: [null],
      productName: [null, [Validators.required, Validators.maxLength(50)]],
      catalogBrand: [null, Validators.required],
      catalogType: [null, Validators.required],
      price: [0, [Validators.required, Validators.maxLength(9), Validators.min(0)]],
      description: [null, Validators.maxLength(200)],
      availableStock: [0, [Validators.required, Validators.min(0)]],
      reStockThreshold: [0, [Validators.required, Validators.min(0)]],
      maxStockThreshold: [0, [Validators.required, Validators.min(0), Validators.max(1000)]],
      onReorder: [false],
    });

    route.data.pipe(map(res => res.catalogData)).subscribe({
      next: ([brands, types]) => {
        this.catalogBrandSource = brands;
        this.catalogTypeSource = types;
      }
    });

    route.params.subscribe(p => {
      catalogService.GetCatalogItemById(Number(p.Id)).subscribe(item => {
        this.catalogItem = item;
        this.catalogBrandSelectedValue = this.catalogItem.catalogBrandCode.toString();
        this.catalogTypeSelectedValue = this.catalogItem.catalogTypeCode.toString();
        this.catalogItemForm.patchValue({
          id: [this.catalogItem.id],
          productName: [this.catalogItem.productName],
          price: [this.catalogItem.price],
          description: [this.catalogItem.description],
          availableStock: [this.catalogItem.availableStock],
          reStockThreshold: [this.catalogItem.restockThreshold],
          maxStockThreshold: [this.catalogItem.maxStockThreshold],
          onReorder: [this.catalogItem.onReorder],
        });
      });
    });
  }

  ngOnInit(): void {

  }

  Reset() {
    this.catalogItemForm.reset();
    this.InitializeFormGroup();
  }

  InitializeFormGroup() {
    this.catalogItemForm = this.fb.group({
      id: [this.catalogItem.id],
      productName: [this.catalogItem.productName, [Validators.required, Validators.maxLength(50)]],
      catalogBrand: [this.catalogItem.catalogBrandCode, Validators.required],
      catalogType: [this.catalogItem.catalogTypeCode, Validators.required],
      price: [this.catalogItem.price, [Validators.required, Validators.maxLength(9), Validators.min(0)]],
      description: [this.catalogItem.description, Validators.maxLength(200)],
      availableStock: [this.catalogItem.availableStock, [Validators.required, Validators.min(0)]],
      reStockThreshold: [this.catalogItem.restockThreshold, [Validators.required, Validators.min(0)]],
      maxStockThreshold: [this.catalogItem.maxStockThreshold, [Validators.required, Validators.min(0), Validators.max(1000)]],
      onReorder: [this.catalogItem.onReorder],
    });
  }

  Submit() {
    // const type = ['', 'info', 'success', 'warning', 'danger'];
    this.notification.ShowNotification(
      'top',
      'right',
      'success',
      '这里是测试消息弹出',
      'notifications'
    );
  }
}
