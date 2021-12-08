using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shop
{
	public class ShopHandler : MonoBehaviour
	{
		[SerializeField] private ProductHolder _productHolderPrefab;
		[SerializeField] private Transform _contentProducts;

		private List<ProductHolder> _products = new List<ProductHolder>();

		private void Awake()
		{
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
	}
}
