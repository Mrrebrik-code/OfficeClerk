using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Interactive.Things
{
	public class WaterInfo : MonoBehaviour
	{
		public TMP_Text _valueText;

		public void SetValue(float value)
		{
			_valueText.text = value.ToString() + "%";
		}
	}
}
