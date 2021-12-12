using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ExecutionList
{
	public class Execution : MonoBehaviour
	{
		private ExecutionInfo _info;

		[SerializeField] private Image _icon;
		[SerializeField] private TMP_Text _timeText;

		private float _timeCurrent;

		public void Init(ExecutionInfo info)
		{
			_info = info;
			_icon.sprite = _info.Icon;

			_timeCurrent = _info.Time;
		}
	}
}
