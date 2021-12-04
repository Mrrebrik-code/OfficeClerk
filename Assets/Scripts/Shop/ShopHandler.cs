using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
	private List<Product> _products = new List<Product>();

	private void Awake()
	{
		LoadProducts();
	}

	private bool LoadProducts()
	{
		_products = Resources.LoadAll<Product>("Products").ToList();
		return _products != null;
	}
}
