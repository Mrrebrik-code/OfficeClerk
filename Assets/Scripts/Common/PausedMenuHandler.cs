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
		[SerializeField] private PausedMenu _pausedMenu;
		public override void Awake()
		{
			base.Awake();
		}

		public void OpenSettings()
		{
			_settings.SetActive(true);
		}

		public void OpenPausedMenu()
		{
			if (_pausedMenu.gameObject.activeInHierarchy == false) _pausedMenu.gameObject.SetActive(true);
			_pausedMenu.Activate();
		}
	}
}


