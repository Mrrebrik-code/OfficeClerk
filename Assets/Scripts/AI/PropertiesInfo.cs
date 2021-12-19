using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AI
{
	public class PropertiesInfo : MonoBehaviour
	{
		[SerializeField] private List<TMP_Text> _infoTexts;

		public void SetInfo(WorkmanProperties properties)
		{
			foreach (var text in _infoTexts)
			{
				text.text =
					$"Жажда: {properties.ThirstValue}%" +
					$"\nГолод: {properties.HungryValue}%" +
					$"\nУсталость: {properties.DreamValue}%";
			}
		}
	}
}
