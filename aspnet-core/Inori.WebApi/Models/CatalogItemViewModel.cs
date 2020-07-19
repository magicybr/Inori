namespace Inori.WebApi.Models
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }

        public int CatalogTypeCode { get; set; }

        public int CatalogBrandCode { get; set; }

        public int AvailableStock { get; set; }

        public int RestockThreshold { get; set; }

        public int MaxStockThreshold { get; set; }

        public bool OnReorder { get; set; }
    }
}