using System;
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
		[SerializeField] private HandTutorial _hand;
		public void Init(TypeCategoryProduct type)
		{
			_type = type;
			_button.onClick.AddListener(Click);
			switch (type)
			{
				case TypeCategoryProduct.Eat:
					_hand.Type = TypeHandTutorial.EatCategory;
					TutorialManager.Instance.AddHand(_hand);
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
			_hand.Complet();
		}
	}
}

