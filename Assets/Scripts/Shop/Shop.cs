using Menu;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
	public class Shop : PanelTable
	{
		[SerializeField] private ProductHolder _productHolderPrefab;
		[SerializeField] private ButtonProductCategory _buttonCategotyPrefab;
		[SerializeField] private ContentProductCategory _contentCategotyPrefab;

		[SerializeField] private GameObject _contentCategorys;
		[SerializeField] private GameObject _contentButtons;

		private Dictionary<TypeCategoryProduct, ContentProductCategory> _categorys = new Dictionary<TypeCategoryProduct, ContentProductCategory>();
		public List<ProductHolder> Init(Dictionary<TypeCategoryProduct, List<Product>> categorys)
		{
			Dictionary<TypeCategoryProduct, object[]> categorysProduct = new Dictionary<TypeCategoryProduct, object[]>();
			List<ProductHolder> products = new List<ProductHolder>();
			foreach (var category in categorys.Keys)
			{
				var button = Instantiate(_buttonCategotyPrefab, _contentButtons.transform);
				var content = Instantiate(_contentCategotyPrefab, _contentCategorys.transform);
				button.Init(category);
				var complect = new object[2] { content, button };

				_categorys.Add(category, content);
				categorysProduct.Add(category, complect);
			}

			foreach (var categoryProducts in categorys.Values)
			{
				foreach (var categoryProduct in categoryProducts)
				{
					var content = categorysProduct[categoryProduct.Category][0];
					var button = categorysProduct[categoryProduct.Category][1] as ButtonProductCategory;
					button.OnClick += OpenCatalog;

					ProductHolder productHolderTemp = Instantiate(_productHolderPrefab, ((ContentProductCategory)content).transform);
					productHolderTemp.SetProduct(categoryProduct);

					products.Add(productHolderTemp);
				}
			}

			return products;
		}

		private void OpenCatalog(TypeCategoryProduct typeCatalog)
		{
			foreach (var category in _categorys.Values)
			{
				category.gameObject.SetActive(false);
			}

			_categorys[typeCatalog].gameObject.SetActive(true);
		}
	}
}

