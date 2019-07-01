using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System;
using System.Linq;

namespace Zadatak_Sven_Jakabfi_Components.CalculatorEngine
{
	public class MilkDiscountPriceDecorator : ProductPriceCalculatorDec
	{
		public MilkDiscountPriceDecorator(IProductPriceCalculator productPriceCalculator)
			: base(productPriceCalculator)
		{

		}

		public override void CalculatePrice()
		{
			Item milkItem = Items.FirstOrDefault(x => x.Product.Code == "Milk");

			if (milkItem?.Quantity > 3)
			{
				int discountQoef = milkItem.Quantity / 4;
				double discount = discountQoef * milkItem.Product.Price;

				milkItem.ProductTotal = Math.Round(milkItem.ProductTotal - discount, 2);
				AppliedDiscounts.Add(Discounts.MilkDiscount);
			}
		}
	}
}
