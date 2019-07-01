using System.Collections.Generic;
using System.Linq;
using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;

namespace Zadatak_Sven_Jakabfi_Components.CalculatorEngine
{
	public abstract class ProductPriceCalculatorDec : IProductPriceCalculator
	{
		IProductPriceCalculator _productPriceCalculator;
		public List<Item> Items { get; }
		public List<Discounts> AppliedDiscounts { get; set; }

		protected IProductPriceCalculator ProductPriceCalculator
		{
			get { return _productPriceCalculator; }
		}

		public ProductPriceCalculatorDec(IProductPriceCalculator productPriceCalculator)
		{
			_productPriceCalculator = productPriceCalculator;
			Items = productPriceCalculator.Items;
			AppliedDiscounts = productPriceCalculator.AppliedDiscounts;
		}

		public virtual void CalculatePrice()
		{ }

		public virtual List<string> GetAppliedDiscounts()
		{
			return AppliedDiscounts.Select(x => x.ToString()).ToList();
		}

		public virtual double GetTotal()
		{
			return _productPriceCalculator.GetTotal();
		}
	}
}
