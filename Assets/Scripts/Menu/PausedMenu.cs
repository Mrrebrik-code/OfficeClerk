using UnityEngine;


namespace Menu
{
	public class PausedMenu : MonoBehaviour
	{
		[SerializeField] private Animator _animator;
		private bool _isShow = false;
		public void Activate()
		{
			_isShow = !_isShow;

			if (_isShow) Show();
			else Hide();
		}
		private void Show()
		{
			_animator.SetTrigger("Show");
		}

		private void Hide()
		{
			_animator.SetTrigger("Hide");
		}

		private void DeactiveObject()
		{
			gameObject.SetActive(false);
			Time.timeScale = 1;
		}
	}
}
