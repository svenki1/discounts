using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System.Collections.Generic;
using System.Linq;
using Zadatak_Sven_Jakabfi_Components.Providers;

namespace Zadatak_Sven_Jakabfi_Tests.ShoppingBasketTests.Providers
{
	public class ProductProvider : IProductProvider
	{
		public ProductModel GetProductByCode(string itemCode)
		{
			return Data.products.FirstOrDefault(x => x.Code == itemCode);
		}

		public	List<ProductModel> GetProducts()
		{
			return Data.products;
		}
	}
}
