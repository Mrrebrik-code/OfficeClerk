﻿using AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
	public class UIPropertiesInfo : MonoBehaviour
	{
		[SerializeField] private Slider _thirstSlider;
		[SerializeField] private Slider _hungrySlider;
		[SerializeField] private Slider _dreamSlider;


		public void SetProperties(WorkmanProperties properties)
		{
			_thirstSlider.value = properties.ThirstValue;
			_hungrySlider.value = properties.HungryValue;
			_dreamSlider.value = properties.DreamValue;
		}
	}
}
