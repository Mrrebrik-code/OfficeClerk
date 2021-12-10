using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
	public class ResetScrollbar : MonoBehaviour
	{
		private Scrollbar _scrollbar;

		private void OnEnable()
		{
			if(_scrollbar == null) Start();
			_scrollbar.value = 1f;
		}

		private void Start()
		{
			_scrollbar = GetComponent<Scrollbar>();
		}
	}
}
