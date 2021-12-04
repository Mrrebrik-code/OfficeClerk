using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Handlers 
{
	public class PausedMenuHandler : MonoBehaviour
	{
		public static PausedMenuHandler Instance;
		[SerializeField] private GameObject _settings;

		private void Awake()
		{
			Instance = this;
		}

		public void OpenSettings()
		{
			_settings.SetActive(true);
		}
	}
}


