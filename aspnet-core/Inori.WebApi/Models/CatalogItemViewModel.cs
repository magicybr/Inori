namespace Inori.WebApi.Models
{
    public class CatalogItemViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// ��Ʒ����
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ��Ʒ�۸�
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// ͼƬ�ļ���
        /// </summary>
        public string PictureFileName { get; set; }

        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string PictureUri { get; set; }

        public int CatalogTypeCode { get; set; }


        public int CatalogBrandCode { get; set; }

        /// <summary>
        /// �������(Quantity in stock)
        /// </summary>
        public int AvailableStock { get; set; }

        /// <summary>
        /// Available stock at which we should reorder
        /// ���ÿ��
        /// </summary>
        public int RestockThreshold { get; set; }


        /// <summary>
        /// Maximum number of units that can be in-stock at any time (due to physicial/logistical constraints in warehouses)
        /// ��Ʒ����������
        /// </summary>
        public int MaxStockThreshold { get; set; }

        /// <summary>
        /// True if item is on reorder
        /// ���¶���
        /// </summary>
        public bool OnReorder { get; set; }
    }
}