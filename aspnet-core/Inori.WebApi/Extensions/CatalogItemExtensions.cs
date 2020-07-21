using Inori.WebApi.Models;

namespace Inori.WebApi.Extensions
{

    public static class CatalogItemViewModelExtensions
    {
        public static void FillProductUrl(this CatalogItemViewModel item, string picBaseUrl)
        {
            if (item != null)
            {
                item.PictureUri = picBaseUrl.Replace("[0]", item.Id.ToString());
            }
        }
    }
}