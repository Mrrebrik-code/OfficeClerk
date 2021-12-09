using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
	public class ProductHolder : MonoBehaviour
	{
		public Product Product { get; private set; }
		[SerializeField] private TMP_Text _nameProductText;
		[SerializeField] private TMP_Text _priceProductText;
		[SerializeField] private Image _imageProduct;


		public void SetProduct(Product product)
		{
			Product = product;
			_nameProductText.text = product.Name;
			_priceProductText.text = product.Price.ToString();
			_imageProduct.sprite = product.Sprite;
		}

		public void Buy()
		{
			ShopHandler.Instance.TryBuy(Product.Type);
		}
	}
}

