using System;
using System.Collections.Generic;
using System.Linq;
using Zadatak_Sven_Jakabfi_Components.CalculatorEngine;
using Zadatak_Sven_Jakabfi_Components.Logger;
using Zadatak_Sven_Jakabfi_Components.Providers;
using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;

namespace Zadatak_Sven_Jakabfi_Components.ShoppingBasket
{
	public class ShoppingBasket : IShoppingBasket
	{
		#region Constructor

		public ShoppingBasket(IProductProvider productProvider, FileLogger logger)
		{
			Items = new List<Item>();
			_productProvider = productProvider;
			_logger = logger;
		}

		#endregion

		#region Fields

		private IProductProvider _productProvider;
		FileLogger _logger;

		#endregion

		#region Props

		private List<Item> Items { get; set; }

		#endregion

		#region Public

		public List<Item> AddItem(string productCode)
		{
			if (!ProductExists(productCode))
			{
				ProductModel newProduct = _productProvider.GetProductByCode(productCode);
				if(newProduct != null)
				{
					Item newItem = new Item(newProduct, 1);
					Items.Add(newItem);
				}
			}
			else
			{
				foreach (var item in Items.Where(x => x.Product.Code == productCode))
					item.Quantity += 1;
			}

			return Items;
		}

		public List<Item> RemoveItem(string productCode)
		{
			if (ProductExists(productCode))
			{
				foreach (var item in Items.Where(x => x.Product.Code == productCode))
					item.Quantity -= 1;
			}

			foreach (var item in Items.Where(x => x.Quantity == 0))
				Items.Remove(item);

			return Items;
		}

		public double GetTotal()
		{
			List<Type> priceCaluclatorImplementations = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
				.Where(x => typeof(ProductPriceCalculatorDec).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

			IProductPriceCalculator priceCalculator = new PriceCalculator(Items);
			priceCalculator.CalculatePrice();

			foreach (var implementation in priceCaluclatorImplementations)
			{
				priceCalculator = (IProductPriceCalculator)Activator.CreateInstance(implementation, new object[] { priceCalculator });
				priceCalculator.CalculatePrice();
			}


			_logger.Info(new { ItemsInfo = priceCalculator.Items, AppliedDiscounts = priceCalculator.GetAppliedDiscounts() });

			return priceCalculator.GetTotal();
		}

		#endregion

		#region Private

		private bool ProductExists(string productCode)
		{
			return Items.Any(x => x.Product.Code == productCode);
		}

		#endregion
	}
}
