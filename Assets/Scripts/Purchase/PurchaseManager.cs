using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class PurchaseManager : SingletonMono<PurchaseManager>
{
	[SerializeField] private Transform _cookiesContent;
	[SerializeField] private Transform _diamondsContent;

	[SerializeField] private ProductPurchaseHolder _purchaseHolderPrefab;
	private Dictionary<PurchaseProduct, ProductPurchaseHolder> _purchases = new Dictionary<PurchaseProduct, ProductPurchaseHolder>();

	[SerializeField] private PurchaseMenu _purchaseMenu;
	private void Start()
	{
		Init();
	}

	public void Open(TypePurchaseMenu type)
	{
		_purchaseMenu.gameObject.SetActive(true);
		switch (type)
		{
			case TypePurchaseMenu.Cookies:
				_purchaseMenu.OpenCookiesPurchase();
				break;
			case TypePurchaseMenu.Diamonds:
				_purchaseMenu.OpenDiamondsPurchase();
				break;
		}
	}

	private List<PurchaseProduct> LoadPurchases()
	{
		return Resources.LoadAll<PurchaseProduct>("Purchase").ToList();
	}
	private void Init()
	{
		var purchases = LoadPurchases();
		if (purchases == null) return;

		foreach (var purchase in purchases)
		{
			ProductPurchaseHolder purchaseHolder = null;
			switch (purchase.Type)
			{
				case TypePurchase.Cookie:
					purchaseHolder = Instantiate(_purchaseHolderPrefab, _cookiesContent);
					break;
				case TypePurchase.Diamond:
					purchaseHolder = Instantiate(_purchaseHolderPrefab, _diamondsContent);
					break;
			}
			purchaseHolder.Init(purchase);
			_purchases.Add(purchase, purchaseHolder);
		}
	}

	public void BuyProduct(PurchaseProduct purchase)
	{
		if(purchase.Type == TypePurchase.Cookie)
		{
			Bank.BankManager.Instance.Diamonds.Withdraw(purchase.Price, callback =>
			{
				if (callback)
				{
					Bank.BankManager.Instance.Cookies.Put(purchase.Count);
				}
			});
		}
		else
		{
			//Логика покупки алмазов зв валюту: Яп от Яндекс API. Пока что приммитивно сделаю.
			Bank.BankManager.Instance.Diamonds.Put(purchase.Count);
		}
		
	}
}
