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
  constructor(
    private route: ActivatedRoute,
    private notification: NotificationService,
    private fb: FormBuilder,
    private catalogService: CatalogService
  ) {

    route.params.subscribe(p => {
      catalogService.GetCatalogItemById(Number(p.Id)).subscribe(item => this.catalogItem = item);
    });

    route.data.pipe(map(res => res.catalogData)).subscribe({
      next: ([brands, types]) => {
        this.catalogBrandSource = brands;
        this.catalogTypeSource = types;
      }
    });

    // console.log(this.catalogItem);

    this.catalogItemForm = this.fb.group({
      id: [this.catalogItem.Id],
      productName: [this.catalogItem.ProductName, [Validators.required, Validators.maxLength(50)]],
      catalogBrand: [this.catalogItem.CatalogBrandCode, Validators.required],
      catalogType: [this.catalogItem.CatalogTypeCode, Validators.required],
      price: [this.catalogItem.Price, [Validators.required, Validators.maxLength(9), Validators.min(0)]],
      description: [this.catalogItem.Description, Validators.maxLength(200)],
      availableStock: [this.catalogItem.AvailableStock, [Validators.required, Validators.min(0)]],
      reStockThreshold: [this.catalogItem.RestockThreshold, [Validators.required, Validators.min(0)]],
      maxStockThreshold: [this.catalogItem.MaxStockThreshold, [Validators.required, Validators.min(0), Validators.max(1000)]],
      onReorder: [this.catalogItem.OnReorder],
    });

    // this.catalogItemForm = this.fb.group({
    //   id: [null],
    //   productName: ['', [Validators.required, Validators.maxLength(50)]],
    //   catalogBrand: ['', Validators.required],
    //   catalogType: ['', Validators.required],
    //   price: [0, [Validators.required, Validators.maxLength(9), Validators.min(0)]],
    //   description: ['', Validators.maxLength(200)],
    //   availableStock: [0, [Validators.required, Validators.min(0)]],
    //   reStockThreshold: [0, [Validators.required, Validators.min(0)]],
    //   maxStockThreshold: [0, [Validators.required, Validators.min(0), Validators.max(1000)]],
    //   onReorder: [false],
    // });
  }

  ngOnInit(): void {

  }

  Reset() {
    this.catalogItemForm.reset();
    this.InitializeFormGroup();
  }

  InitializeFormGroup() {
    this.catalogItemForm = this.fb.group({
      id: [this.catalogItem.Id],
      productName: [this.catalogItem.ProductName, [Validators.required, Validators.maxLength(50)]],
      catalogBrand: [this.catalogItem.CatalogBrandCode, Validators.required],
      catalogType: [this.catalogItem.CatalogTypeCode, Validators.required],
      price: [this.catalogItem.Price, [Validators.required, Validators.maxLength(9), Validators.min(0)]],
      description: [this.catalogItem.Description, Validators.maxLength(200)],
      availableStock: [this.catalogItem.AvailableStock, [Validators.required, Validators.min(0)]],
      reStockThreshold: [this.catalogItem.RestockThreshold, [Validators.required, Validators.min(0)]],
      maxStockThreshold: [this.catalogItem.MaxStockThreshold, [Validators.required, Validators.min(0), Validators.max(1000)]],
      onReorder: [this.catalogItem.OnReorder],
    });
    // this.catalogItemForm.setValue({
    //   id: null,
    //   productName: '',
    //   catalogBrand: '',
    //   catalogType: '',
    //   price: 0,
    //   description: '',
    //   availableStock: 0,
    //   reStockThreshold: 0,
    //   maxStockThreshold: 0,
    //   onReorder: false,
    // });
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
