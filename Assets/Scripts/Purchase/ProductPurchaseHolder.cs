using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductPurchaseHolder : MonoBehaviour
{
	[SerializeField] private Image _image;
	[SerializeField] private TMP_Text _priceText;
	[SerializeField] private TMP_Text _countText;
	private PurchaseProduct _purchase;
	public void Init(PurchaseProduct purchase)
	{
		_purchase = purchase;
		_priceText.text = _purchase.Price.ToString();
		_countText.text = _purchase.Count.ToString();
		_image.sprite = _purchase.Icon;
	}
	public void Buy()
	{
		PurchaseManager.Instance.BuyProduct(_purchase);
	}
}
