using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadatak_Sven_Jakabfi_Components.CalculatorEngine
{
	public class PriceCalculator : IProductPriceCalculator
	{
		public List<Item> Items { get; }
		public List<Discounts> AppliedDiscounts { get; set; }

		public PriceCalculator(List<Item> _items)
		{
			Items = _items;
			AppliedDiscounts = new List<Discounts>();
		}

		public void CalculatePrice()
		{
			foreach (var item in Items)
				item.ProductTotal = Math.Round(item.Quantity * item.Product.Price, 2);
		}

		public double GetTotal()
		{
			return Math.Round(Items.Sum(x => x.ProductTotal), 2);
		}

		public List<string> GetAppliedDiscounts()
		{
			return AppliedDiscounts.Select(x => x.ToString()).ToList();
		}
	}
}
