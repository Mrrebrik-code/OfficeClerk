using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Execution
{
	public class Execution : MonoBehaviour
	{
		private ExecutionInfo _info;

		[SerializeField] private Image _icon;
		[SerializeField] private TMP_Text _timeText;

		private float _timeCurrent;

		public Action<Execution> OnDestroyAction { get; internal set; }

		public void Init(ExecutionInfo info)
		{
			_info = info;
			_icon.sprite = _info.Icon;

			_timeCurrent = _info.Time;

			StartCoroutine(Delay());
		}

		private IEnumerator Delay()
		{
			for (float i = _timeCurrent; i > 0; i--)
			{
				_timeText.text = $"{i}c";
				yield return new WaitForSeconds(1f);
			}
			DestroyImmediate(gameObject);
		}
	}
}
