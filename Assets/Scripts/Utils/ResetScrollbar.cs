using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
	public class ResetScrollbar : MonoBehaviour
	{
		private Scrollbar _scrollbar;
		[SerializeField] private bool _invert = false;

		private void OnEnable()
		{
			if(_scrollbar == null) Start();
			if (_invert) _scrollbar.value = 0f;
			else _scrollbar.value = 1f;
		}

		private void Start()
		{
			_scrollbar = GetComponent<Scrollbar>();
		}
	}
}
