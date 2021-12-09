using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
	public class ProductHolder : MonoBehaviour
	{
		public Product Product { get; private set; }


		public void SetProduct(Product product)
		{
			Product = product;
		}

		public void Buy()
		{
			ShopHandler.Instance.TryBuy(Product.Type);
		}
	}
}

