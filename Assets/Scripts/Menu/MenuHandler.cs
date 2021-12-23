using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
	public class MenuHandler : MonoBehaviour
	{
		[SerializeField] private FaderOut _fader;
		public void Play()
		{
			_fader.FaderIn(() =>
			{
				SceneManager.LoadScene("_Game");
			});
		}
	}
}
