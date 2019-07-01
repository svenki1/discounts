using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System.Collections.Generic;

namespace Zadatak_Sven_Jakabfi_Components.Providers
{
	public interface IProductProvider
	{
		ProductModel GetProductByCode(string itemCode);
		List<ProductModel> GetProducts();
	}
}
