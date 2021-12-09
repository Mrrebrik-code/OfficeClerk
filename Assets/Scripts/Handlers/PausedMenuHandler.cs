using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace Handlers 
{
	public class PausedMenuHandler : SingletonMono<PausedMenuHandler>
	{
		[SerializeField] private GameObject _settings;
		public override void Awake()
		{
			base.Awake();
		}

		public void OpenSettings()
		{
			_settings.SetActive(true);
		}
	}
}


