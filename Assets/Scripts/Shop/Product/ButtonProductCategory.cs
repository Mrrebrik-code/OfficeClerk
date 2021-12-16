using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Shop
{
	public class ButtonProductCategory : MonoBehaviour
	{
		public Action<TypeCategoryProduct> OnClick;
		[SerializeField] private TMP_Text _nameButtonText;
		[SerializeField] private Button _button;
		[SerializeField] private TypeCategoryProduct _type;

		public void Init(TypeCategoryProduct type)
		{
			_type = type;
			_button.onClick.AddListener(Click);
			switch (type)
			{
				case TypeCategoryProduct.Eat:
					_nameButtonText.text = "Продукты";
					break;
				case TypeCategoryProduct.Workman:
					_nameButtonText.text = "Сотрудники";
					break;
				case TypeCategoryProduct.Office:
					_nameButtonText.text = "Офис";
					break;
			}
		}

		private void Click()
		{
			OnClick?.Invoke(_type);
		}
	}
}

