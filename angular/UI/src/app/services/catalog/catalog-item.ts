export class CatalogItem {
  Id: number;
  ProductName: string;
  Description: string;
  Price: number;
  PictureFileName: string;
  PictureUri: string;
  CatalogTypeCode: string;
  CatalogTypeName: string;
  CatalogBrandCode: string;
  CatalogBrandName: string;
  AvailableStock: number;
  RestockThreshold: number;
  MaxStockThreshold: number;
  OnReorder: boolean;
}

export const CatalogItemList: CatalogItem[] = [
  {
    Id: 1,
    ProductName: '麦卡伦蓝钻12年',
    Description: '麦卡伦蓝钻12年（Macallan）单一麦芽威士忌 双雪莉桶 苏格兰进口洋酒700ml',
    Price: 419,
    PictureFileName: '',
    PictureUri: '',
    CatalogTypeCode: '1',
    CatalogTypeName: '威士忌',
    CatalogBrandCode: '1',
    CatalogBrandName: '麦卡伦',
    AvailableStock: 100,
    RestockThreshold: 100,
    MaxStockThreshold: 100,
    OnReorder: false
  },
  {
    Id: 2,
    ProductName: '百龄坛12年',
    Description: '百龄坛（Ballantine’s）洋酒 12年 经典调配 苏格兰 威士忌 500ml',
    Price: 139,
    PictureFileName: '',
    PictureUri: '',
    CatalogTypeCode: '1',
    CatalogTypeName: '威士忌',
    CatalogBrandCode: '2',
    CatalogBrandName: '百龄坛',
    AvailableStock: 100,
    RestockThreshold: 100,
    MaxStockThreshold: 100,
    OnReorder: false
  },
  {
    Id: 3,
    ProductName: '角瓶',
    Description: '日本原装进口洋酒威士忌 三得利（Suntory）角瓶调配调和 威士忌1.92L',
    Price: 340,
    PictureFileName: '',
    PictureUri: '',
    CatalogTypeCode: '1',
    CatalogTypeName: '威士忌',
    CatalogBrandCode: '3',
    CatalogBrandName: '三得利',
    AvailableStock: 80,
    RestockThreshold: 80,
    MaxStockThreshold: 80,
    OnReorder: false
  },
  {
    Id: 4,
    ProductName: '人头马V.S.O.P干邑白兰地',
    Description: '人头马（Rémy Martin）洋酒 V.S.O.P优质香槟区干邑白兰地 375ml',
    Price: 238,
    PictureFileName: '',
    PictureUri: '',
    CatalogTypeCode: '2',
    CatalogTypeName: '白兰地',
    CatalogBrandCode: '4',
    CatalogBrandName: '人头马',
    AvailableStock: 50,
    RestockThreshold: 50,
    MaxStockThreshold: 50,
    OnReorder: false
  },
  {
    Id: 5,
    ProductName: '轩尼诗V.S.O.P干邑白兰地',
    Description: '轩尼诗（Hennessy）洋酒 V.S.O.P干邑白兰地',
    Price: 426,
    PictureFileName: '',
    PictureUri: '',
    CatalogTypeCode: '2',
    CatalogTypeName: '白兰地',
    CatalogBrandCode: '5',
    CatalogBrandName: '轩尼诗',
    AvailableStock: 75,
    RestockThreshold: 75,
    MaxStockThreshold: 75,
    OnReorder: false
  }
];
