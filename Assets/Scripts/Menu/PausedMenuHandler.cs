using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace Menu 
{
	public class PausedMenuHandler : SingletonMono<PausedMenuHandler>
	{
		[SerializeField] private GameObject _tableMenu;
		[SerializeField] private PausedMenu _pausedMenu;
		public override void Awake()
		{
			base.Awake();
		}

		public void OpenTableMenu()
		{
			_tableMenu.SetActive(true);
			Time.timeScale = 0;
		}
		public void CloseTableMenu()
		{
			_tableMenu.SetActive(false);
			Time.timeScale = 1;
		}
		public void OpenSettings()
		{
			
		}
		public void CloseSettings()
		{

		}

		public void OpenPausedMenu()
		{
			if (_pausedMenu.gameObject.activeInHierarchy == false)
			{
				Time.timeScale = 0;
				_pausedMenu.gameObject.SetActive(true);
			}
			_pausedMenu.Activate();
		}
	}
}


