using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using System;
using System.Linq;

namespace Zadatak_Sven_Jakabfi_Components.CalculatorEngine
{
	public class ButterDiscountPriceDecorator : ProductPriceCalculatorDec
	{
		public ButterDiscountPriceDecorator(IProductPriceCalculator productPriceCalculator)
			: base(productPriceCalculator)
		{

		}

		public override void CalculatePrice()
		{
			Item butterItem = Items.FirstOrDefault(x => x.Product.Code == "Butter");
			Item breadItem = Items.FirstOrDefault(x => x.Product.Code == "Bread");

			if (butterItem?.Quantity >= 2 && breadItem != null)
			{
				int discountQoef = butterItem.Quantity / 2 > breadItem.Quantity ? breadItem.Quantity : butterItem.Quantity /2 ;

				breadItem.ProductTotal = Math.Round(breadItem.ProductTotal - (discountQoef * breadItem.Product.Price * 0.5), 2);

				AppliedDiscounts.Add(Discounts.ButterDiscount);
			}
		}
	}
}
