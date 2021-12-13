using UnityEngine;
using TMPro;
using Utils;

namespace FPS
{
	[RequireComponent(typeof(FramePerSecond))]
	class FPSDisplay : SingletonMono<FPSDisplay>
	{
		[SerializeField] private TMP_Text _fpsCounterText;
		private FramePerSecond _fpsCounter;
		[SerializeField] private GameObject _panel;

		private string[] _stringsFrom00To9999 = new string[9999];

		public override void Awake()
		{
			base.Awake();
			_fpsCounter = GetComponent<FramePerSecond>();
			for (int i = 0; i < 9999; i++)
			{
				_stringsFrom00To9999[i] = i.ToString();
			}
		}
		public void Activate(bool isActive)
		{
			_panel.SetActive(isActive);
		}
		private void Update()
		{
			_fpsCounterText.text = "FPS: " + _stringsFrom00To9999[(_fpsCounter.AverageFPS)];
		}
	}
}


