using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Interactive.Things
{
	public class InfoBurgerStand : MonoBehaviour
	{
		[SerializeField] private TMP_Text _countBurgersText;
		[SerializeField] private Slider _progressBarCooking;
		public void SetCountBurgers(int count)
		{
			_countBurgersText.text = $"{count}/5";
		}

		public void UpdateProgressBar(float value)
		{
			_progressBarCooking.value = value;
		}

		public void SetMaxValueProgressBar(float value)
		{
			_progressBarCooking.maxValue = value;
		}

	}
}
