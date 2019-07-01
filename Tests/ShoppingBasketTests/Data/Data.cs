using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System.Collections.Generic;

namespace Zadatak_Sven_Jakabfi_Tests.ShoppingBasketTests
{
	public static class Data
	{
		public static List<ProductModel>  products = new List<ProductModel>
		{
			new ProductModel{ Id = 1, Code = "Butter", Price = 0.80},
			new ProductModel{ Id = 2, Code = "Milk", Price = 1.15},
			new ProductModel{ Id = 3, Code = "Bread", Price = 1.00}
		};
	}
}
