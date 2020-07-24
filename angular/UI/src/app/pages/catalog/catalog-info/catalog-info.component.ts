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
  public catalogItem: CatalogItem;
  catalogItemForm: FormGroup;
  catalogBrandSelectedValue: string;
  catalogTypeSelectedValue: string;
  constructor(
    private route: ActivatedRoute,
    private notification: NotificationService,
    private fb: FormBuilder,
    private catalogService: CatalogService
  ) {
    console.log('ctor');
    route.data.pipe(map(res => res.catalogData)).subscribe({
      next: ([brands, types, item]) => {
        this.catalogBrandSource = brands;
        this.catalogTypeSource = types;
        this.catalogItem = item;
      }
    });

    this.catalogItemForm = this.fb.group({
      id: [this.catalogItem.id],
      productName: [this.catalogItem.productName, [Validators.required, Validators.maxLength(50)]],
      catalogBrand: [this.catalogItem.catalogBrandCode.toString(), Validators.required],
      catalogType: [this.catalogItem.catalogTypeCode.toString(), Validators.required],
      price: [this.catalogItem.price, [Validators.required, Validators.maxLength(9), Validators.min(0)]],
      description: [this.catalogItem.description, Validators.maxLength(200)],
      availableStock: [this.catalogItem.availableStock, [Validators.required, Validators.min(0)]],
      reStockThreshold: [this.catalogItem.restockThreshold, [Validators.required, Validators.min(0)]],
      maxStockThreshold: [this.catalogItem.maxStockThreshold, [Validators.required, Validators.min(0), Validators.max(1000)]],
      onReorder: [this.catalogItem.onReorder],
    });
  }

  ngOnInit(): void {
    console.log('init');
    console.log(this.catalogItem);
    // console.log($('#catalogItemPic'));
    // $('#catalogItemPic').fileinput({
    //   initialPreview: [
    //     '<img alt="..." src="http://localhost:5001/api/catalog/items/1/pic/">'
    //   ]
    // });

    // tslint:disable-next-line:only-arrow-functions
    $('#catalogItemPic').fileinput({
      url: '',
      dataType: 'json',
      autoupload: false,
      acceptFileTypes: /(gif|jpe?g|png)$/i,
      maxFileSize: 1000000, // 1 MB
      imageMaxWidth: 100,
      message: {
        acceptFileTypes: '文件类型不匹配',
        maxFileSize: '文件过大',
        minFileSize: '文件过小'
      },
    }).on('change.bs.fileinput', function (e, data, previewId, index) {
      console.log(e);
      console.log(data);
    }).on('clear.bs.fileinput', function (e) {
      console.log('clear.bs.fileinput');
    }).on('reset.bs.fileinput', function (e) {
      console.log('reset.bs.fileinput');
    }).on('reseted.bs.fileinput', function (e) {
      console.log('reseted.bs.fileinput');
    }).on('max_size.bs.fileinput', function (e) {
      console.log('max_size.bs.fileinput');
    });

    $('#catalogItemPic2').fileinput({
      url: '',
      dataType: 'json',
      autoupload: false,
      acceptFileTypes: /(gif|jpe?g|png)$/i,
      maxFileSize: 1000000, // 1 MB
      imageMaxWidth: 100,
      message: {
        acceptFileTypes: '文件类型不匹配',
        maxFileSize: '文件过大',
        minFileSize: '文件过小'
      },
    }).on('change.bs.fileinput', function (e, data, previewId, index) {
      console.log(e);
      console.log(data);
    }).on('clear.bs.fileinput', function (e) {
      console.log('clear.bs.fileinput');
    }).on('reset.bs.fileinput', function (e) {
      console.log('reset.bs.fileinput');
    }).on('reseted.bs.fileinput', function (e) {
      console.log('reseted.bs.fileinput');
    }).on('max_size.bs.fileinput', function (e) {
      console.log('max_size.bs.fileinput');
    });
  }
  ngAfterViewInit() {
    console.log('after init');
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
