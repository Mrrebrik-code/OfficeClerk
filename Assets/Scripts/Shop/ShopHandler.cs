using Interactive;
using Interactive.Things;
using Shop.Delivery;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using Factories;
using Core;
using Bank;

namespace Shop
{
	public class ShopHandler : SingletonMono<ShopHandler>
	{
		[SerializeField] private ProductHolder _productHolderPrefab;
		[SerializeField] private Transform _contentProducts;
		[SerializeField] private CategoryProductButton _categoryButtonPrefab;
		[SerializeField] private ContentCategoryProduct _contentProductCategoryPrefab;

		private List<ProductHolder> _products = new List<ProductHolder>();
		private Dictionary<TypeCategoryProduct, ContentCategoryProduct> _productHolders = new Dictionary<TypeCategoryProduct, ContentCategoryProduct>();

		public override void Awake()
		{
			base.Awake();
		}

		private List<Product> LoadProducts()
		{
			return Resources.LoadAll<Product>("Products").ToList();
		}

		public void OpenCategoryShop(TypeCategoryProduct category)
		{

		}

		public void Init(Transform contentButtons, Transform contentCategory)
		{

			List<Product> products = LoadProducts();
			if (products == null) return;

			var categorys = new Dictionary<TypeCategoryProduct, object[]>();

			foreach (var product in products)
			{
				var productCategory = Instantiate(_contentProductCategoryPrefab, contentCategory);
				productCategory.gameObject.SetActive(false);

				var buttonCategory = Instantiate(_categoryButtonPrefab, contentButtons);
				buttonCategory.Init(productCategory.gameObject);

				categorys.Add(product.Category, new object[2]{ productCategory, product });

			}

			foreach (var content in categorys.Values)
			{
				ProductHolder productHolderTemp = Instantiate(_productHolderPrefab, ((GameObject)content[0]).transform);
				productHolderTemp.SetProduct(content[1] as Product);

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
				case TypeProduct.Workman:
					var workman = FactoryWorkmanAI.Instance.Create(1);
					GameManager.Instance.AddWorkman(workman);
					break;
			}

			return true;
		}
	}
}
