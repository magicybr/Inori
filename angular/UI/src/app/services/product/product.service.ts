import { Injectable } from '@angular/core';
import { ServicesModule } from '../services.module';
import { Product } from './product';
import { Observable, of } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';
const PRODUCTS: Product[] = [
  {
    id: 1,
    productName: '商品1',
    description: '商品描述1',
    catalogType: '商品类别1',
    pictureFileName: '图片名称1',
    pictureUri: '图片链接1',
    price: 100,
    catalogBrand: 'Brand1'
  },
  {
    id: 2,
    productName: '商品2',
    description: '商品描述2',
    catalogType: '商品类别2',
    pictureFileName: '图片名称2',
    pictureUri: '图片链接2',
    price: 200,
    catalogBrand: 'Brand2'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
  {
    id: 3,
    productName: '商品3',
    description: '商品描述3',
    catalogType: '商品类别3',
    pictureFileName: '图片名称3',
    pictureUri: '图片链接3',
    price: 100,
    catalogBrand: 'Brand3'
  },
];

@Injectable({
  providedIn: ServicesModule
})
export class ProductService {
  // id: number;
  // productName: string;
  // description: string;
  // catalogType: string;
  // pictureFileName: string;
  // pictureUri: string;
  // price: number;
  // catalogBrand: string;
  form = this.fb.group({
    id: [null],
    productName: ['', Validators.required],
    catalogBrand: [''],
    catalogTYpe: [''],
    description: [''],
    pictureFileName: [''],
    pictureUri: [''],
    price: [0],
  });

  constructor(private fb: FormBuilder) {
    console.log(fb);
  }

  GetProducts(): Observable<Product[]> {
    return of(PRODUCTS);
  }

  FindProduct() {

  }

  AddProduct() {

  }

  UpdateProduct() {

  }

  RemoveProduct() {

  }
}
