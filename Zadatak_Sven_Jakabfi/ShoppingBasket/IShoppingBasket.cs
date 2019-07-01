using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System.Collections.Generic;

namespace Zadatak_Sven_Jakabfi_Components.ShoppingBasket
{
	public interface IShoppingBasket
	{
		List<Item> AddItem(string itemCode);
		List<Item> RemoveItem(string itemCode);
		double GetTotal();
	}
}
