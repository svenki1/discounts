using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak_Sven_Jakabfi_Components.Logger;
using Zadatak_Sven_Jakabfi_Components.ShoppingBasket;
using Zadatak_Sven_Jakabfi_Models.ShoppingBasket;
using Zadatak_Sven_Jakabfi_Tests.ShoppingBasketTests.Providers;

namespace Zadatak_Sven_Jakabfi_Tests.ShoppingBasketTests
{
	[TestClass]
	public class ShoppingBasketTest
	{
		public ShoppingBasketTest()
		{
			_shoppingBasket = new ShoppingBasket(new ProductProvider(), new FileLogger());
		}

		private IShoppingBasket _shoppingBasket { get; set; }

		#region AddProductTests

		[TestMethod]
		public void Should_Add_One_Milk_To_Basket()
		{
			var items = _shoppingBasket.AddItem(Consts.MilkCode);

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.MilkCode).Quantity, 1);
		}

		[TestMethod]
		public void Should_Add_One_Bread_To_Basket()
		{
			var items = _shoppingBasket.AddItem(Consts.BreadCode);

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.BreadCode).Quantity, 1);
		}

		[TestMethod]
		public void Should_Add_One_Butter_To_Basket()
		{
			var items = _shoppingBasket.AddItem(Consts.ButterCode);

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.ButterCode).Quantity, 1);
		}

		[TestMethod]
		public void Should_Not_Add_Not_Existing_To_Basket()
		{
			var items = _shoppingBasket.AddItem(string.Empty);

			Assert.AreNotEqual(items.FirstOrDefault(x => x.Product.Code == string.Empty)?.Quantity, 1);
		}

		[TestMethod]
		public void Should_Add_Multiple_Milk_To_Basket()
		{
			List<Item> items = AddItemsToBasket();

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.MilkCode).Quantity, Consts.AddNumberOfItems);
		}

		[TestMethod]
		public void Should_Add_Multiple_Bread_To_Basket()
		{
			List<Item> items = AddItemsToBasket();

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.BreadCode).Quantity, Consts.AddNumberOfItems);
		}

		[TestMethod]
		public void Should_Add_Multiple_Butter_To_Basket()
		{
			List<Item> items = AddItemsToBasket();

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.ButterCode).Quantity, Consts.AddNumberOfItems);
		}

		#endregion

		#region RemoveTests

		[TestMethod]
		public void Should_Remove_Butter_From_Basket()
		{
			List<Item> items = AddItemsToBasket();

			for (int i = 1; i <= Consts.RemoveNumberOfItems; i++)
				items = _shoppingBasket.RemoveItem(Consts.ButterCode);

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.ButterCode).Quantity, Consts.AddNumberOfItems - Consts.RemoveNumberOfItems);
		}

		[TestMethod]
		public void Should_Remove_Milk_From_Basket()
		{
			List<Item> items = AddItemsToBasket();

			for (int i = 1; i <= Consts.RemoveNumberOfItems; i++)
				items = _shoppingBasket.RemoveItem(Consts.MilkCode);

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.MilkCode).Quantity, Consts.AddNumberOfItems - Consts.RemoveNumberOfItems);
		}

		[TestMethod]
		public void Should_Remove_Bread_From_Basket()
		{
			List<Item> items = AddItemsToBasket();

			for (int i = 1; i <= Consts.RemoveNumberOfItems; i++)
				items = _shoppingBasket.RemoveItem(Consts.BreadCode);

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.BreadCode).Quantity, Consts.AddNumberOfItems - Consts.RemoveNumberOfItems);
		}

		[TestMethod]
		public void Should_Not_Remove_Bread_From_Basket()
		{
			List<Item> items = AddItemsToBasket();

			for (int i = 1; i <= Consts.RemoveNumberOfItems; i++)
				items = _shoppingBasket.RemoveItem(Consts.ButterCode);

			Assert.AreEqual(items.FirstOrDefault(x => x.Product.Code == Consts.BreadCode).Quantity, Consts.AddNumberOfItems);
		}

		[TestMethod]
		public void Should_Not_Remove_From_Basket()
		{
			List<Item> items = AddItemsToBasket();

			int basketTotalCount = items.Sum(x => x.Quantity);

			for (int i = 1; i <= Consts.RemoveNumberOfItems; i++)
				items = _shoppingBasket.RemoveItem(string.Empty);

			Assert.AreEqual(items.Sum(x => x.Quantity), basketTotalCount);
		}

		#endregion

		#region CalculationTests

		[TestMethod]
		public void Should_Return_Zero()
		{
			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 0.00);
		}

		[TestMethod]
		public void Should_Return_Total_Of_One_Milk()
		{
			_shoppingBasket.AddItem(Consts.MilkCode);
			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 1.15);
		}

		[TestMethod]
		public void Should_Return_Total_Of_One_Bread()
		{
			_shoppingBasket.AddItem(Consts.BreadCode);
			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 1.00);
		}

		[TestMethod]
		public void Should_Return_Total_Of_One_Butter()
		{
			_shoppingBasket.AddItem(Consts.ButterCode);
			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 0.80);
		}

		[TestMethod]
		public void Should_Return_Total_Of_Two_Milk()
		{
			_shoppingBasket.AddItem(Consts.MilkCode);
			_shoppingBasket.AddItem(Consts.MilkCode);

			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 2.30);
		}

		[TestMethod]
		public void Should_Return_Total_Of_Two_Bread()
		{
			_shoppingBasket.AddItem(Consts.BreadCode);
			_shoppingBasket.AddItem(Consts.BreadCode);

			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 2.00);
		}

		[TestMethod]
		//Also should not apply butter discount as there is no bread in basket
		public void Should_Return_Total_Of_Two_Butter()
		{
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);

			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 1.60);
		}

		[TestMethod]
		public void Should_Apply_Butter_Discount()
		{
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.BreadCode);

			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 2.10);
		}

		[TestMethod]
		public void Should_Apply_Butter_Discount_On_Only_One_Bread()
		{
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.BreadCode);
			_shoppingBasket.AddItem(Consts.BreadCode);

			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 3.10);
		}

		[TestMethod]
		public void Should_Apply_Butter_Discount_On_Only_Bread()
		{
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.ButterCode);
			_shoppingBasket.AddItem(Consts.BreadCode);

			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 5.3);
		}

		[TestMethod]
		public void Should_Apply_Milk_Discount()
		{
			_shoppingBasket.AddItem(Consts.MilkCode);
			_shoppingBasket.AddItem(Consts.MilkCode);
			_shoppingBasket.AddItem(Consts.MilkCode);
			_shoppingBasket.AddItem(Consts.MilkCode);

			double total = _shoppingBasket.GetTotal();

			Assert.AreEqual(total, 3.45);
		}

		[TestMethod]
		public void Should_Apply_Milk_Butter_Discount()
		{
			AddItemsToBasket();

			double total = _shoppingBasket.GetTotal();
			
			Assert.AreEqual(total, 24.7);
		}

		#endregion

		#region Helper

		private List<Item> AddItemsToBasket()
		{
			List<Item> items = new List<Item>();

			for (int i = 1; i <= Consts.AddNumberOfItems; i++)
			{
				items = _shoppingBasket.AddItem(Consts.BreadCode);
				items = _shoppingBasket.AddItem(Consts.MilkCode);
				items = _shoppingBasket.AddItem(Consts.ButterCode);
			}

			return items;
		}

		#endregion
	}
}
