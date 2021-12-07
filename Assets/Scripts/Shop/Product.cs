﻿using UnityEngine;

namespace Shop
{
	[CreateAssetMenu(fileName = "product", menuName = "Shop/Product")]
	public class Product : ScriptableObject
	{
		public int Id;
		public TypeProduct Type;
		public string Name;
		public string Description;
		public int Price;

		public int LevelUp;
	}
}

