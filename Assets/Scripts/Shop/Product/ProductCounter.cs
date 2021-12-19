using System;
using TMPro;
using UnityEngine;

namespace Shop
{
	public class ProductCounter : MonoBehaviour
	{
		public Action OnUpdateCounter;
		[SerializeField] private TMP_Text _countText;
		private int _count;
		public int Count 
		{ 
			get{ return _count; } 
			private set 
			{
				_count = value;

				if(_count >= 10) _count = 10;
				else if(_count <= 0) _count = 1;

				_countText.text = _count.ToString();
				OnUpdateCounter?.Invoke();
			} 
		}

		public void OnEnable()
		{
			Count = 1;
		}
		public void Plus()
		{
			Count += 1;
		}
		public void Minus()
		{
			Count -= 1;
		}
	}
}
