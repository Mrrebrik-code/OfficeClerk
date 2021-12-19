using Bank;
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
		[SerializeField] private ProductCounter _counter;

		public void SetProduct(Product product)
		{
			Product = product;
			_nameProductText.text = product.Name;
			_imageProduct.sprite = product.Sprite;
			UpdatePriceProduct();

			_counter.OnUpdateCounter += UpdatePriceProduct;
		}

		private void UpdatePriceProduct()
		{
			_priceProductText.text = (_counter.Count * Product.Price).ToString();
		}

		public void Buy()
		{
			var price = Product.Price * _counter.Count;
			BankManager.Instance.Cookies.Withdraw(price, (callback) =>
			{
				if (callback)
				{
					ShopHandler.Instance.TryBuy(Product.Type, _counter.Count);
				}
				else
				{
					Debug.LogError("Не хватает печенек для покупки!");
				}
			});
		}
	}
}

