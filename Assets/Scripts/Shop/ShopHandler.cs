using Interactive;
using Interactive.Things;
using Shop.Delivery;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using Factories;
using Core;

namespace Shop
{
	public class ShopHandler : SingletonMono<ShopHandler>
	{
		[SerializeField] private Shop _shop;
		Dictionary<TypeCategoryProduct, List<Product>> _products = new Dictionary<TypeCategoryProduct, List<Product>>();
		public override void Awake()
		{
			base.Awake();
			Init();
		}

		private List<Product> LoadProducts()
		{
			return Resources.LoadAll<Product>("Products").ToList();
		}

		public void Init()
		{
			List<Product> products = LoadProducts();
			if (products == null) return;

			List<Product> _productsEat = new List<Product>();
			List<Product> _productsWorkman = new List<Product>();
			List<Product> _productsOffice = new List<Product>();

			List<TypeCategoryProduct> _categorys = new List<TypeCategoryProduct>();


			foreach (var product in products)
			{
				switch (product.Category)
				{
					case TypeCategoryProduct.Eat:
						_productsEat.Add(product);
						break;
					case TypeCategoryProduct.Workman:
						_productsWorkman.Add(product);
						break;
					case TypeCategoryProduct.Office:
						_productsOffice.Add(product);
						break;
				}

				if (_categorys.Contains(product.Category) == false)
				{
					_categorys.Add(product.Category);
				}
			}
			foreach (var category in _categorys)
			{
				List<Product> productsCategory = new List<Product>();
				foreach (var product in products)
				{
					if (product.Category == category)
					{
						productsCategory.Add(product);
					}
				}
				_products.Add(category, productsCategory);
			}
			_shop.Init(_products);
		}

		public bool TryBuy(TypeProduct typeProduct, int count = 1)
		{

			switch (typeProduct)
			{
				case TypeProduct.Burger:
					BurgerStand.Instance.CookingBurgers(count);
					break;
				case TypeProduct.WaterBox:
					FactoryWaterBox.Instance.Create(count);
					DeliveryManager.Instance.SetDeliveryTarget(TypeObject.WaterBox, 1);
					break;
				case TypeProduct.Workman:
					if (GameManager.Instance.CountFreeToBuyTables() >= count)
					{
						for (int i = 0; i < count; i++)
						{
							var workman = FactoryWorkmanAI.Instance.Create(1);
							GameManager.Instance.AddWorkman(workman);
						}
					}
					else
					{
						Bank.BankManager.Instance.History.UndoTransaction();
					}
					break;
				case TypeProduct.Table:
					if (GameManager.Instance.HasFreeNoBuyTables() >= count)
					{
						for (int i = 0; i < count; i++)
						{
							GameManager.Instance.AddTable();
						}
					}
					else
					{
						Bank.BankManager.Instance.History.UndoTransaction();
					}
					break;
			}

			return true;
		}
	}
}
