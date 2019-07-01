namespace Zadatak_Sven_Jakabfi_Models.ShoppingBasket
{
	public class Item
	{
		public Item(ProductModel product, int quantity)
		{
			Product = product;
			Quantity = quantity;
		}

		public ProductModel Product { get; set; }
		public int Quantity { get; set; }
		public double ProductTotal;
	}
}
