using Interactive;
using Interactive.Things;
using Shop.Delivery;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using Factories;

namespace Shop
{
	public class ShopHandler : SingletonMono<ShopHandler>
	{
		[SerializeField] private ProductHolder _productHolderPrefab;
		[SerializeField] private Transform _contentProducts;

		private List<ProductHolder> _products = new List<ProductHolder>();

		public override void Awake()
		{
			base.Awake();
			Init();
		}

		private List<Product> LoadProducts()
		{
			return Resources.LoadAll<Product>("Products").ToList();
		}

		private void Init()
		{
			List<Product> products = LoadProducts();
			if (products == null) return;

			foreach (var product in products)
			{
				ProductHolder productHolderTemp = Instantiate(_productHolderPrefab, _contentProducts);
				productHolderTemp.SetProduct(product);

				_products.Add(productHolderTemp);
			}
		}

		public bool TryBuy(TypeProduct typeProduct, int count = 1)
		{
			switch(typeProduct)
			{
				case TypeProduct.Burger:
					BurgerStand.Instance.CookingBurgers(count);
					break;
				case TypeProduct.WaterBox:
					FactoryWaterBox.Instance.Create(count);
					DeliveryManager.Instance.SetDeliveryTarget(TypeObject.WaterBox, 1);
					break;
			}

			return true;
		}
	}
}
