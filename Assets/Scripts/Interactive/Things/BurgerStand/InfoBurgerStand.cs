using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Interactive.Things
{
	public class InfoBurgerStand : MonoBehaviour
	{
		[SerializeField] private TMP_Text _countBurgersText;

		public void SetCountBurgers(int count)
		{
			_countBurgersText.text = $"{count}/5";
		}
	}
}
