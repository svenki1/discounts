using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System.Collections.Generic;

namespace Zadatak_Sven_Jakabfi_Components.CalculatorEngine
{
	public interface IProductPriceCalculator
	{
		List<Item> Items { get; }
		List<Discounts> AppliedDiscounts {get; set;}
		void CalculatePrice();
		double GetTotal();
		List<string> GetAppliedDiscounts();
	}
}
