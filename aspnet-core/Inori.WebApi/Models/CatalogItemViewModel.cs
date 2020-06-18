namespace Inori.WebApi.Models
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 图片文件名
        /// </summary>
        public string PictureFileName { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string PictureUri { get; set; }

        public int CatalogTypeCode { get; set; }


        public int CatalogBrandCode { get; set; }

        /// <summary>
        /// 库存数量(Quantity in stock)
        /// </summary>
        public int AvailableStock { get; set; }

        /// <summary>
        /// Available stock at which we should reorder
        /// 可用库存
        /// </summary>
        public int RestockThreshold { get; set; }


        /// <summary>
        /// Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
        /// 商品库存最大数量
        /// </summary>
        public int MaxStockThreshold { get; set; }

        /// <summary>
        /// True if item is on reorder
        /// 重新订购
        /// </summary>
        public bool OnReorder { get; set; }
    }
}