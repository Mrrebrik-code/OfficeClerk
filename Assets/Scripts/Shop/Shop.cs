using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
	public class Shop : MonoBehaviour
	{
		[SerializeField] private Transform _contentButtons;
		[SerializeField] private Transform _contentCategorys;

		public Transform[] GetContentsOfTransform()
		{
			return new Transform[2] { _contentButtons, _contentCategorys };
		}
	}
}

