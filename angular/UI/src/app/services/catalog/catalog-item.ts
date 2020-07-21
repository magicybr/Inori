export class CatalogItem {
  id: number;
  productName: string;
  description: string;
  price: number;
  pictureFileName: string;
  pictureUri: string;
  catalogTypeCode: string;
  // CatalogTypeName: string;
  catalogBrandCode: string;
  // CatalogBrandName: string;
  availableStock: number;
  restockThreshold: number;
  maxStockThreshold: number;
  onReorder: boolean;
}

export const CatalogItemList: CatalogItem[] = [

];
